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
    public partial class FrmConsultarCliente : Form
    {
        private ClienteSocket clienteSocket;
        public FrmConsultarCliente(ClienteSocket socket)
        {
            InitializeComponent();
            ConfigurarColumnas();
            this.Load += FrmConsultarCliente_Load;
            clienteSocket = socket;

        }
        //Método para configurar columnas
        private void ConfigurarColumnas()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear(); // Para prevenir duplicaciones

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Identificacion",
                HeaderText = "Identificación",
                DataPropertyName = "Identificacion"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrimerApellido",
                HeaderText = "Primer Apellido",
                DataPropertyName = "PrimerApellido"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SegundoApellido",
                HeaderText = "Segundo Apellido",
                DataPropertyName = "SegundoApellido"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaNacimiento",
                HeaderText = "Fecha Nacimiento",
                DataPropertyName = "FechaNacimiento"
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Activo",
                HeaderText = "Activo",
                DataPropertyName = "Activo"
            });
        }

        private void FrmConsultarCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
        
        }
        //Método para carga de Clientes
        private void CargarClientes()
        {
            try
            {
                ClienteDAO dao = new ClienteDAO();
                List<ClienteDTO> clientes = dao.ObtenerTodosLosClientes();

                //Datos para la tabla
                var listavisual = clientes.Select(c => new
                {
                    c.Identificacion,
                    c.Nombre,
                    c.PrimerApellido,
                    c.SegundoApellido,
                    FechaNacimiento = c.FechaNacimiento.ToString("d/MM/yyyy"),
                    Activo = c.Activo ? "Sí" : "No"

                }).ToList();

                dgvClientes.DataSource = listavisual;

            }
            catch (Exception ex)
            { 
                MessageBox.Show("Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        
        }

        //Método para boton Volver a menú principal
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        
        }
    }
}
