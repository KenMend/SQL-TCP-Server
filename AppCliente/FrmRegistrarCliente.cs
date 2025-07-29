using AppCliente.Red;
using CapaAccesoDatosSql;
using CapaEntidades;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing.Text;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;


namespace AppCliente
{
    public partial class FrmRegistrarCliente : Form
    {
        private ClienteSocket clienteSocket;
        public FrmRegistrarCliente(ClienteSocket socket)
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FrmRegistrarCliente_Load);
            clienteSocket = socket;
        }

        private void FrmRegistrarCliente_Load(object sender, EventArgs e)
        {
            cmbActivo.Items.Clear();
            cmbActivo.Items.Add("Sí");
            cmbActivo.Items.Add("No");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            new FrmRegistrarCliente(clienteSocket).ShowDialog();
            //Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text)||
                string.IsNullOrWhiteSpace(txtPrimerApellido.Text)||
                string.IsNullOrWhiteSpace(txtSegundoApellido.Text)||
                cmbActivo.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                //Obtener los datos del formulario
                string nombre = txtNombre.Text.Trim();
                string primerApellido = txtPrimerApellido.Text.Trim();
                string segundoApellido = txtSegundoApellido.Text.Trim();
                DateTime fechaNacimiento = dtpFechaNacimiento.Value.Date;
                bool activo = cmbActivo.SelectedItem.ToString() == "Sí";

                //Generar un ID único aleatorio entre 1000 y 9999
                Random rand = new Random();
                int identificacion = rand.Next(1000, 10000);

                ClienteDAO dao = new ClienteDAO();

                //Se asegura que el ID cliente no exista
                while (dao.ExisteCliente(identificacion))
                {
                    identificacion = rand.Next(1000, 10000);

                }

                //Se crea el objeto ClienteDTO
                ClienteDTO cliente = new ClienteDTO
                {
                    Identificacion = identificacion,
                    Nombre = nombre,
                    PrimerApellido = primerApellido,
                    SegundoApellido = segundoApellido,
                    FechaNacimiento = fechaNacimiento,
                    Activo = activo

                };


                //Se intenta registrar el cliente
                bool registrado = dao.RegistrarCliente(cliente);

                if (registrado)
                {
                    MessageBox.Show("Cliente registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();

                }
                else
                {
                    MessageBox.Show("No se pudo registrar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }      
        }
        //Método para limpiar campos
        private void LimpiarCampos()
        { 
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            cmbActivo.SelectedIndex = -1;

        }
    }
}
