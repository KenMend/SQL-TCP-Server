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
/**
 * UNED II Cuatrimestres 2025
 * Proyecti 2: Redes, Colecciones, Subprocesos, Sql Bases de Datos
 * Estudiante: Keneth Mendez Torres
 * Fecha: 27/7/2025
 * */
namespace AppCliente
{
    public partial class FrmConsultarPedidos : Form
    {
        private ClienteSocket clienteSocket;
        private PedidoDAO pedidoDAO = new PedidoDAO();
        private DetallePedidoDAO detalleDAO = new DetallePedidoDAO();

        public FrmConsultarPedidos(ClienteSocket socket)
        {
            InitializeComponent();
            ConfigurarColumnasDetalle();
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.MultiSelect = false;
            dgvDetallePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetallePedido.MultiSelect = false;
            dgvPedidos.SelectionChanged += dgvPedidos_SelectionChanged;
            clienteSocket = socket;
        }

        

        //Método Load
        private void FrmConsultarPedidos_Load(object sender, EventArgs e)
        {
            CargarEncabezados();
        }

        private void CargarEncabezados()
        {

            var pedidos = pedidoDAO.ObtenerTodosLosPedidos();

            dgvDetallePedido.Rows.Clear();

            foreach (var p in pedidos)
            {
                dgvPedidos.Rows.Add(
                    p.NumeroPedido,
                    p.FechaPedido.ToString("dd/MM/yyyy"),
                    p.Cliente.Identificacion,
                    p.Cliente.Nombre,
                    p.Cliente.PrimerApellido,
                    p.Cliente.SegundoApellido,
                    p.Repartidor.Identificacion,
                    p.Repartidor.Nombre,
                    p.Repartidor.PrimerApellido,
                    p.Repartidor.SegundoApellido,
                    p.DireccionEntrega);

            }
        
        }
        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count > 0)
            {
                int numeroPedido = Convert.ToInt32(dgvPedidos.SelectedRows[0].Cells[0].Value);
                CargarDetalles(numeroPedido);
            }

        }
        private void ConfigurarColumnasDetalle()
        {
            dgvDetallePedido.AutoGenerateColumns = false;
            dgvDetallePedido.Columns.Clear();

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdArticulo",
                HeaderText = "Id Artículo",
                DataPropertyName = "IdArticulo"
            });

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreArticulo",
                HeaderText = "Nombre Artículo",
                DataPropertyName = "NombreArticulo"
            });

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TipoArticulo",
                HeaderText = "Tipo Artículo",
                DataPropertyName = "TipoArticulo"
            });

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad"
            });

            dgvDetallePedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Monto",
                HeaderText = "Monto",
                DataPropertyName = "Monto"
            });
        }

        //Método para cargar detalles
        private void CargarDetalles(int numeroPedido)
        {
            var detalles = detalleDAO.ObtenerDetallesPorPedido(numeroPedido);

            var visual = detalles.Select(d => new
            {
                IdArticulo = d.Articulo.Id,
                NombreArticulo = d.Articulo.Nombre,
                TipoArticulo = d.Articulo.TipoArticulo.Nombre,
                d.Cantidad,
                d.Monto
            }).ToList();

            dgvDetallePedido.DataSource = visual;
        }

        //Método para volver a menu
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
    
}
