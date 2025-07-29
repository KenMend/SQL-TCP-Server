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
    public partial class FrmRegistrarTipoArticulo : Form
    {
        private ClienteSocket clienteSocket;
        public FrmRegistrarTipoArticulo(ClienteSocket socket)
        {
            InitializeComponent();
            clienteSocket = socket;
        }
        private void FrmRegistrarTipoArticulo_Load(object sender, EventArgs e)
        {
            // Inicialización si aplica
        }



        //Lógica para el boton Guardar, junto con las validaciones correspondientes
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            new FrmRegistrarTipoArticulo(clienteSocket).ShowDialog();

            //Validar que no hayan campos vacíos
            if (string.IsNullOrWhiteSpace(txtId.Text)||
                string.IsNullOrWhiteSpace(txtNombre.Text)||
                string.IsNullOrWhiteSpace(TxtDescripcion.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Validar que el ID sea númerico (únicamente)
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("El ID debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //Crear DTO
                TipoArticuloDTO tipo = new TipoArticuloDTO
                {
                    Id = id,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = TxtDescripcion.Text.Trim()
                };

                TipoArticuloDAO dao = new TipoArticuloDAO();

                //Validar si ya existe
                if (dao.ExisteTipoArticulo(id))
                {
                    MessageBox.Show("Ya existe un tipo de artículo con ese ID", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Intentar registrar
                bool resultado = dao.RegistrarTipoArticulo(tipo);

                if (resultado)
                {
                    MessageBox.Show("Tipo de artículo registrado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el tipo de artículo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            
            }
        
        }
        //Método que limpia los campos
        private void LimpiarCampos()
        { 
            txtId.Clear();
            txtNombre.Clear();
            TxtDescripcion.Clear();
        
        }

    }
}
