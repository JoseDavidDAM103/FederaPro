using System;
using System.Windows.Forms;

namespace FederaProDesktop.Karting
{
    public partial class DetalleEquipoKartingControl : UserControl
    {
        private string nombreEquipo;
        private string paisEquipo;

        public DetalleEquipoKartingControl(string nombre, string pais)
        {
            InitializeComponent();
            nombreEquipo = nombre;
            paisEquipo = pais;
            CargarDetalles();
        }

        private void CargarDetalles()
        {
            txtNombre.Text = nombreEquipo;
            txtPais.Text = paisEquipo;
        }
    }
}
