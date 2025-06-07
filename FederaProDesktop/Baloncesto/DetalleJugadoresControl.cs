using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop
{
    public partial class DetalleJugadorControl : UserControl
    {


        public DetalleJugadorControl(string nombre, string posicion)
        {
            InitializeComponent();
            lblTitulo.Text = $"{nombre} | Posición: {posicion}";
            MostrarEstadisticasPartido();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            MostrarEstadisticasPartido();
        }

        private void btnEstadisticasAnuales_Click(object sender, EventArgs e)
        {
            MostrarEstadisticasAnuales();
        }

        private void MostrarEstadisticasPartido()
        {
            panelContenido.Controls.Clear();
            // Agrega aquí el control deseado para estadísticas por partido
        }

        private void MostrarEstadisticasAnuales()
        {
            panelContenido.Controls.Clear();
            // Agrega aquí el control deseado para estadísticas del año
        }
    }
}
