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
    public partial class FrmConsultarTipoArticulo : Form
    {
        private ClienteSocket clienteSocket;
        public FrmConsultarTipoArticulo(ClienteSocket socket)
        {
            InitializeComponent();
            dgvTiposArticulo.AutoGenerateColumns = false;
            dgvTiposArticulo.MultiSelect = false;
            dgvTiposArticulo.Columns.Clear();
            clienteSocket = socket;

        }

        //Método Load
        private void FrmConsultarTipoArticulo_Load(object sender, EventArgs e)
        {
            

            // Solo agregar columnas si aún no existen
            if (dgvTiposArticulo.Columns.Count == 0)
            {
                dgvTiposArticulo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Id",
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    Width = 100
                });

                dgvTiposArticulo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Nombre",
                    HeaderText = "Nombre",
                    DataPropertyName = "Nombre",
                    Width = 200
                });

                dgvTiposArticulo.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Descripcion",
                    HeaderText = "Descripción",
                    DataPropertyName = "Descripcion",
                    Width = 300
                });

            }

            CargarTiposArticulo();

        }

        private void CargarTiposArticulo()
        {
            try
            {
                TipoArticuloDAO dao = new TipoArticuloDAO();
                List<TipoArticuloDTO> lista = dao.ObtenerTodosLosTipos();

                dgvTiposArticulo.DataSource = lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de artículos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //Método con la lógica para boton volver al menú principal
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

        }


    }
}
