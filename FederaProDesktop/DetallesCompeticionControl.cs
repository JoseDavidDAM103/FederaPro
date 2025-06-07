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
    public partial class DetallesCompeticionControl : UserControl
    {
        public DetallesCompeticionControl(string nombreCompeticion, string tipo)
        {
            InitializeComponent();

            lblTitulo.Text = $"{nombreCompeticion} | Tipo: {tipo}";
        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {
            CargarContenido(new Label { Text = "Equipos participantes...", AutoSize = true });
        }

        private void btnPartidos_Click(object sender, EventArgs e)
        {
            CargarContenido(new Label { Text = "Lista de partidos...", AutoSize = true });
        }

        private void btnClasificacion_Click(object sender, EventArgs e)
        {
            CargarContenido(new Label { Text = "Clasificación...", AutoSize = true });
        }

        private void CargarContenido(Control control)
        {
            panelContenido.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }
    }
}
