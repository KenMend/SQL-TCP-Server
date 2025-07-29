using AppServidor.Red;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppServidor
{
    public partial class FrmServidor : Form
    {
        private ServidorSocket servidor;
        public FrmServidor()
        {
            InitializeComponent();

            servidor = new ServidorSocket();

            //Enlazar eventos
            servidor.OnLog += AgregarBitacora;
            servidor.OnClientesConectadosChanged += ActualizarClientes;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            servidor.Start();
            AgregarBitacora("Servidor iniciado.");
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            servidor.Stop();
            AgregarBitacora("Servidor detenido.");
        }

        private void AgregarBitacora(string mensaje)
        {
            if (txtBitacora.InvokeRequired)
            {
                txtBitacora.Invoke(new Action(() => AgregarBitacora(mensaje)));
            }
            else
            {
                txtBitacora.AppendText(mensaje + Environment.NewLine);
            }
        }
        private void ActualizarClientes(int cantidad)
        {
            if (lblClientes.InvokeRequired)
            {
                lblClientes.Invoke(new Action(() => ActualizarClientes(cantidad)));
            }
            else
            {
                lblClientes.Text = $"Clientes conectados: {cantidad}";
            }
        }
    }
}
