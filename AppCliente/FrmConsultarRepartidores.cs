using AppCliente.Red;
using CapaAccesoDatosSql;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
    public partial class FrmConsultarRepartidores : Form
    {
        private ClienteSocket clienteSocket;
        private readonly RepartidorDAO _dao = new RepartidorDAO();

        public FrmConsultarRepartidores(ClienteSocket socket)
        {
            InitializeComponent();
            ConfigurarColumnas();
            this.Load += FrmConsultarRepartidores_Load;
            btnVolver.Click += btnVolver_Click;
            clienteSocket = socket;
        }

        private void FrmConsultarRepartidores_Load(object sender, EventArgs e)
        {
            CargarRepartidores();
        
        }

        //Método de configuración de columnas
        private void ConfigurarColumnas()
        {
            dgvRepartidores.AutoGenerateColumns = false;
            dgvRepartidores.Columns.Clear(); // 🔐 prevenir duplicaciones

            dgvRepartidores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Identificacion",
                HeaderText = "Identificación",
                DataPropertyName = "Identificacion"
            });

            dgvRepartidores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre"
            });

            dgvRepartidores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrimerApellido",
                HeaderText = "Primer Apellido",
                DataPropertyName = "PrimerApellido"
            });

            dgvRepartidores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SegundoApellido",
                HeaderText = "Segundo Apellido",
                DataPropertyName = "SegundoApellido"
            });

            dgvRepartidores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaNacimiento",
                HeaderText = "Fecha Nacimiento",
                DataPropertyName = "FechaNacimiento"
            });

            dgvRepartidores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaContratacion",
                HeaderText = "Fecha Contratación",
                DataPropertyName = "FechaContratacion"
            });
        }


        //Método para la carga de repartidores
        private void CargarRepartidores()
        {
            try
            {
                var lista = _dao.ObtenerTodosLosRepartidores();

                var data = lista.Select(r => new
                {
                    r.Identificacion,
                    r.Nombre,
                    r.PrimerApellido,
                    r.SegundoApellido,
                    FechaNacimiento = r.FechaNacimiento.ToString("dd/MM/yyyy"),
                    FechaContratacion = r.FechaContratacion.ToString("dd/MM/yyyy")

                }).ToList();

                dgvRepartidores.AutoGenerateColumns = false;
                dgvRepartidores.DataSource = data;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los repartidores: " +  ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }  
            
        }
        //Método para btnVolver
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
