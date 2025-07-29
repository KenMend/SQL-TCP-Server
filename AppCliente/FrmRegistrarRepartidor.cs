using AppCliente.Red;
using CapaAccesoDatosSql;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCliente
{
    public partial class FrmRegistrarRepartidor : Form
    {
        private ClienteSocket clienteSocket;
        public FrmRegistrarRepartidor(ClienteSocket socket)
        {
            InitializeComponent();
            clienteSocket = socket;
        }

        private void FrmRegistrarRepartidor_Load(object sender, EventArgs e)
        { 
            cmbActivo.Items.Clear();
            cmbActivo.Items.Add("Sí");
            cmbActivo.Items.Add("No");
        
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            new FrmRegistrarRepartidor(clienteSocket).ShowDialog();
            //Validar que no hayan campos vacíos
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text)||
                string.IsNullOrWhiteSpace(txtNombre.Text)||
                string.IsNullOrWhiteSpace(txtPrimerApellido.Text)||
                string.IsNullOrWhiteSpace(txtSegundoApellido.Text)||
                cmbActivo.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            //Verifica que el número de Identificación sea un número entero
            if (!int.TryParse(txtIdentificacion.Text.Trim(), out int id))
            {
                MessageBox.Show("La identificación debe ser un número entero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            
            }

            DateTime fechaNacimiento = dtpFechaNacimiento.Value.Date;
            DateTime fechaContratacion = dtpFechaContratacion.Value.Date;
            DateTime hoy = DateTime.Today;

            //Valida que el Repartidor sea mayor de edad
            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento > hoy.AddYears(-edad)) edad--;

            if (edad < 18)
            {
                MessageBox.Show("El repartidor debe ser amyor de edad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            //Valida que la fecha de contratación no sea futura
            if (fechaContratacion > hoy)
            {
                MessageBox.Show("La fecha de contratación no puede ser mayor que hoy", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

                
            }

            try
            {
                RepartidorDTO repartidor = new RepartidorDTO
                {
                    Identificacion = id,
                    Nombre = txtNombre.Text.Trim(),
                    PrimerApellido = txtPrimerApellido.Text.Trim(),
                    SegundoApellido = txtSegundoApellido.Text.Trim(),
                    FechaNacimiento = fechaNacimiento,
                    FechaContratacion = fechaContratacion,
                    Activo = cmbActivo.SelectedItem.ToString() == "Sí"

                };


                //Se verifica que no exista un Repartidor con un ID ya existente en la BD
                RepartidorDAO dao = new RepartidorDAO();

                if (dao.ExisteRepartidor(id))
                {
                    MessageBox.Show("Ya existe un repartidor con esa identificación.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool registrado = dao.RegistrarRepartidor(repartidor);

                if (registrado)
                {
                    MessageBox.Show("Repartidor registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el repartidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:" + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        //Método para limpiar campos
        private void LimpiarCampos()
        {
            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            dtpFechaContratacion.Value = DateTime.Today;
            cmbActivo.SelectedIndex = -1;

        }
    }
}
