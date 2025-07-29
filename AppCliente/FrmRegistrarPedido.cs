using AppCliente.Red;
using CapaAccesoDatosSql;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCliente
{
    public partial class FrmRegistrarPedido : Form
    {
        private ClienteSocket clienteSocket;
        private readonly PedidoDAO _pedidoDao = new PedidoDAO();
        private readonly ClienteDAO _clienteDao = new ClienteDAO();
        private readonly RepartidorDAO _repartidorDao = new RepartidorDAO();
        private readonly ArticuloDAO _articuloDao = new ArticuloDAO();

        private readonly List<DetallePedidoDTO> _detalles = new List<DetallePedidoDTO>();

        public FrmRegistrarPedido(ClienteSocket socket)
        {
            InitializeComponent();
            this.Load += FrmRegistrarPedido_Load;
            btnAgregarArticulo.Click += btnAgregarArticulo_Click;
            btnGuardarPedido.Click += btnGuardarPedido_Click;
            clienteSocket = socket;

        }

        private void FrmRegistrarPedido_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();
                ConfigurarGrid();

                //Fecha = hoy
                dtpFechaPedido.Value = DateTime.Today;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        
        }

        private void dgvDetallePedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // vacío
        }

        private void CargarCombos()
        {
            //ComboBox Clientes
            var clientes = _clienteDao.ObtenerTodosLosClientes();
            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = nameof(ClienteDTO.NombreCompleto);
            cmbCliente.ValueMember = nameof(ClienteDTO.Identificacion);
            cmbCliente.SelectedIndex = -1;

            //ComboBox Repartidores
            var repartidores = _repartidorDao.ObtenerTodosLosRepartidores();
            cmbRepartidor.DataSource = repartidores;
            cmbRepartidor.DisplayMember = nameof(RepartidorDTO.NombreCompleto);
            cmbRepartidor.ValueMember = nameof(RepartidorDTO.Identificacion);
            cmbRepartidor.SelectedIndex = -1;

            //ComboBox Artículos
            var articulos = _articuloDao.ObtenerTodosLosArticulos();
            cmbArticulo.DataSource = articulos.FindAll(a => a.Activo && a.Inventario > 0);
            cmbArticulo.DisplayMember = nameof(ArticuloDTO.Nombre);
            cmbArticulo.ValueMember = nameof(ArticuloDTO.Id);
            cmbArticulo.SelectedIndex = -1;

        }

        private void ConfigurarGrid()
        {
            dgvDetallePedido.AutoGenerateColumns = false;
            dgvDetallePedido.Columns.Clear();
            dgvDetallePedido.ReadOnly = true;
            dgvDetallePedido.AllowUserToAddRows = false;
            dgvDetallePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdArticulo",
                HeaderText = "ID Artículo",
                DataPropertyName = "IdArticulo",
                Width = 90
            });

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNombreArticulo",
                HeaderText = "Artículo",
                DataPropertyName = "NombreArticulo",
                Width = 160
            });

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTipoArticulo",
                HeaderText = "Tipo",
                DataPropertyName = "TipoArticulo",
                Width = 120
            });

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                Width = 80
            });

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMonto",
                HeaderText = "Monto",
                DataPropertyName = "Monto",
                Width = 100,
                DefaultCellStyle = { Format = "C2" }
            });

            RefrescarGrid();

        }

        private void RefrescarGrid()
        {
            var binding = new List<dynamic>();

            foreach (var d in _detalles)
            {
                binding.Add(new
                {
                    d.IdArticulo,
                    NombreArticulo = d.Articulo?.Nombre,
                    TipoArticulo = d.Articulo?.TipoArticulo?.Nombre,
                    d.Cantidad,
                    d.Monto

                });

            }

            dgvDetallePedido.DataSource = null;
            dgvDetallePedido.DataSource = binding;
        
        
        }

        //Método para boton Agregar Articulo
        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            new FrmRegistrarPedido(clienteSocket).ShowDialog();
            if (cmbArticulo.SelectedItem == null)
            { 
                MessageBox.Show("Seleccione un artículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            var articulo = (ArticuloDTO)cmbArticulo.SelectedItem;

            //No se permite repertir el artículo en el pedido
            if (_detalles.Exists(x => x.IdArticulo == articulo.Id))
            {
                MessageBox.Show("Este artículo ya fue agregado al pedido. Modifique la cantidad de ser necesario", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Validacion de inventario
            if (cantidad > articulo.Inventario)
            {
                MessageBox.Show("La cantidad digitada excede el inventario disponible", "Inventario insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            
            }

            double monto = articulo.Valor * cantidad * 1.12;

            _detalles.Add(new DetallePedidoDTO
            {
                IdArticulo = articulo.Id,
                Articulo = articulo,
                Cantidad = cantidad,
                Monto = monto

            });

            RefrescarGrid();
            txtCantidad.Clear();
            cmbArticulo.SelectedIndex = -1;

        }

        //Método para guardar el pedido en la BD
        private void btnGuardarPedido_Click(object sender, EventArgs e)
        {
            //Validaciones de encabezado

            //Valida que todos los campos sean llenados
            if (cmbCliente.SelectedItem == null ||
                cmbRepartidor.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Todos los datos son requeridos en el encabezado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            
            }

            //Valida que no se seleccione una fecha pasada
            if (dtpFechaPedido.Value.Date < DateTime.Today)
            {
                MessageBox.Show("La fecha del pedido no puede ser anterior a la fecha actual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Valida que se agregue al menos 1 artículo
            if (_detalles.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un artículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var pedido = new PedidoDTO
                {
                    NumeroPedido = 0,
                    FechaPedido = dtpFechaPedido.Value.Date,
                    Cliente = (ClienteDTO)cmbCliente.SelectedItem,
                    Repartidor = (RepartidorDTO)cmbRepartidor.SelectedItem,
                    DireccionEntrega = txtDireccion.Text.Trim()

                };

                bool ok = _pedidoDao.RegistrarPedido(pedido, _detalles);

                if (ok)
                {
                    MessageBox.Show("Pedido registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LimpiarFormulario()
        {
            _detalles.Clear();
            RefrescarGrid();

            cmbCliente.SelectedIndex = -1;
            cmbRepartidor.SelectedIndex = -1;
            cmbArticulo.SelectedIndex = -1;
            txtDireccion.Clear();
            txtCantidad.Clear();
            dtpFechaPedido.Value = DateTime.Today;

            // Refrescar combos y número (visual)
            CargarCombos();
            txtNumeroPedido.Text = (_pedidoDao.ObtenerUltimoIdPedido() + 1).ToString();
        }


    }




}    
        