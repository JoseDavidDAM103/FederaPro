using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop.Karting
{
    public partial class DetallePilotoControl : UserControl
    {
        private string nombre;
        private string categoria;

        public DetallePilotoControl(string nombre, string categoria)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.categoria = categoria;
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            lblNombre.Text = $"Nombre: {nombre}";
            lblCategoria.Text = $"Categoría: {categoria}";
        }
    }
}
