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
    public partial class FrmConsultarArticulos : Form
    {
        private ClienteSocket clienteSocket;
        private readonly ArticuloDAO _dao = new ArticuloDAO();
        public FrmConsultarArticulos(ClienteSocket socket)
        {
            InitializeComponent();
            clienteSocket = socket;
        }

        private void FrmConsultarArticulos_Load(object sender, EventArgs e)
        {
            CargarArticulos();
        }

        //Método para carga de artículos
        private void CargarArticulos()
        {
            dgvArticulos.Rows.Clear();
            var lista = _dao.ObtenerTodosLosArticulos();

            foreach (var articulo in lista)
            {
                dgvArticulos.Rows.Add(
                    articulo.Id,
                    articulo.Nombre,
                    articulo.TipoArticulo?.Nombre,
                    articulo.Valor.ToString("C"),
                    articulo.Inventario,
                    articulo.Activo ? "Sí" : "No"

                );

            }


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
