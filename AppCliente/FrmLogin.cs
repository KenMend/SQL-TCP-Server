using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCliente.Red;
using CapaComunicaciones.Contracts;
/**
 * UNED II Cuatrimestres 2025
 * Proyecti 2: Redes, Colecciones, Subprocesos, Sql Bases de Datos
 * Estudiante: Keneth Mendez Torres
 * Fecha: 27/7/2025
 * */
namespace AppCliente
{
    public partial class FrmLogin : Form
    {
        private ClienteSocket clienteSocket;

        public FrmLogin()
        {
            InitializeComponent();
            clienteSocket = new ClienteSocket();
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (!int.TryParse(txtIdentificacion.Text.Trim(), out int identificacion))
            {
                lblError.Text = "La identificación debe ser un número.";
                lblError.Visible = true;
                return;
            }
            try
            {
                await clienteSocket.ConectarAsync();
                var loginRequest = new LoginRequest { Identificacion = identificacion };
                var loginResponse = await clienteSocket.LoginAsync(loginRequest);

                if (!loginResponse.Ok)
                {
                    lblError.Text = loginResponse.Message;
                    lblError.Visible = true;
                    return;
                }

                // Guardar cliente y socket estáticamente
                ClienteSession.Cliente = loginResponse.Cliente;
                ClienteSession.Socket = clienteSocket;

                // Mostrar el menú principal
                FrmMenuPrincipal menu = new FrmMenuPrincipal();
                menu.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                lblError.Text = $"Error al conectar: {ex.Message}";
                lblError.Visible = true;
            }


        }

    }
}
