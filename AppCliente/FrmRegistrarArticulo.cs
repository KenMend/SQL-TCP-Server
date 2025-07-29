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
    public partial class FrmRegistrarArticulo : Form
    {
        private ClienteSocket clienteSocket;
        public FrmRegistrarArticulo(ClienteSocket socket)
        {
            InitializeComponent();
            clienteSocket = socket;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            new FrmRegistrarArticulo(clienteSocket).ShowDialog();
            // 1) Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtValor.Text) ||
                string.IsNullOrWhiteSpace(txtInventario.Text) ||
                cmbTipoArticulo.SelectedItem == null ||
                cmbActivo.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtValor.Text, out double valor) || valor <= 0)
            {
                MessageBox.Show("El valor debe ser numérico y mayor que 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtInventario.Text, out int inventario) || inventario < 0)
            {
                MessageBox.Show("El inventario debe ser un número entero mayor o igual que 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dao = new ArticuloDAO();

                // 2) Generar Id aleatorio y garantizar unicidad
                Random rnd = new Random();
                int id = rnd.Next(1000, 10000);
                while (dao.ExisteArticulo(id))
                {
                    id = rnd.Next(1000, 10000);
                }

                // 3) Armar DTO
                var tipoSel = (TipoArticuloDTO)cmbTipoArticulo.SelectedItem;

                var articulo = new ArticuloDTO
                {
                    Id = id,
                    Nombre = txtNombre.Text.Trim(),
                    Valor = valor,
                    Inventario = inventario,
                    Activo = cmbActivo.SelectedItem.ToString() == "Sí",
                    IdTipoArticulo = tipoSel.Id,
                    TipoArticulo = tipoSel
                };

                // 4) Registrar
                bool ok = dao.RegistrarArticulo(articulo);

                if (ok)
                {
                    MessageBox.Show("Artículo registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtValor.Clear();
            txtInventario.Clear();
            cmbTipoArticulo.SelectedIndex = -1;
            cmbActivo.SelectedIndex = -1;
            txtNombre.Focus();
        }

        private void FrmRegistrarArticulo_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }
        private void CargarCombos()
        {
            // Activo
            cmbActivo.Items.Clear();
            cmbActivo.Items.Add("Sí");
            cmbActivo.Items.Add("No");
            cmbActivo.SelectedIndex = 0;

            // Tipos de artículo
            var tipoDao = new TipoArticuloDAO();
            cmbTipoArticulo.DataSource = tipoDao.ObtenerTodosLosTipos();
            cmbTipoArticulo.DisplayMember = "Nombre";
            cmbTipoArticulo.ValueMember = "Id";
            cmbTipoArticulo.SelectedIndex = -1;
        }


    }


}
