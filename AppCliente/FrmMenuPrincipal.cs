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
    public partial class FrmMenuPrincipal : Form
    {
        private ClienteSocket clienteSocket = new ClienteSocket();
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }
        //Boton registrar tipo de artículo
        private void btnRegistrarTipoArticulo_Click(object sender, EventArgs e)
        {
            new FrmRegistrarTipoArticulo(clienteSocket).ShowDialog();
        }

        //Método registrar artículo
        private void btnRegistrarArticulo_Click(object sender, EventArgs e)
        {
            //FrmRegistrarCliente frm = new FrmRegistrarCliente();
            new FrmRegistrarArticulo(clienteSocket).ShowDialog();
        }

        //Método registrar Cliente
        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            //FrmRegistrarCliente frm = new FrmRegistrarCliente();
            new FrmRegistrarCliente(clienteSocket).ShowDialog();
        }

        //Método registrar Repartidor
        private void btnRegistrarRepartidor_Click(object sender, EventArgs e)
        {
            //FrmRegistrarCliente frm = new FrmRegistrarCliente();
            new FrmRegistrarRepartidor(clienteSocket).ShowDialog();
        }

        //Método registrar un pedido
        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            //FrmRegistrarCliente frm = new FrmRegistrarCliente();
            new FrmRegistrarPedido(clienteSocket).ShowDialog();
        }

        //Método consultar tipos de artículos
        private void btnConsultarTipoArticulo_Click(object sender, EventArgs e)
        {
            //FrmRegistrarCliente frm = new FrmRegistrarCliente();
            new FrmConsultarTipoArticulo(clienteSocket).ShowDialog();
        }

        //Método consultar artículos
        private void btnConsultarArticulo_Click(object sender, EventArgs e)
        {
            //FrmRegistrarCliente frm = new FrmRegistrarCliente();
            new FrmConsultarArticulos(clienteSocket).ShowDialog();
        }

        //Método consultar clientes
        private void btnConsultarCliente_Click(object sender, EventArgs e)
        {
            //FrmRegistrarCliente frm = new FrmRegistrarCliente();
            new FrmConsultarCliente(clienteSocket).ShowDialog();
        }

        //Método consultar repartidores
        private void btnConsultarRepartidor_Click(object sender, EventArgs e)
        {
            //FrmRegistrarCliente frm = new FrmRegistrarCliente();
            new FrmConsultarRepartidores(clienteSocket).ShowDialog();
        }

        //Método consultar pedidos
        private void btnConsultarPedido_Click(object sender, EventArgs e)
        {
            //FrmRegistrarCliente frm = new FrmRegistrarCliente();
            new FrmConsultarPedidos(clienteSocket).ShowDialog();
        }

        //Método para botón salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            //lblNombreCliente.Text = $"Bienvenido: {ClienteSession.Cliente.Nombre} {ClienteSession.Cliente.PrimerApellido} {ClienteSession.Cliente.SegundoApellido}";
            try
            {
                await clienteSocket.ConectarAsync(); // Establece la conexión con el servidor
                MessageBox.Show("Conectado al servidor.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar al servidor: {ex.Message}");
            }

        }
    }
}
