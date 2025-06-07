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
    public partial class CircuitosControl : UserControl
    {
        public event Action<string> VerDetalleCircuito;

        public CircuitosControl()
        {
            InitializeComponent();
            CargarCircuitosMock();
        }

        private void CargarCircuitosMock()
        {
            dataGridViewCircuitos.Rows.Clear();
            dataGridViewCircuitos.Rows.Add("Circuito Jerez", "España", "4.43 km");
            dataGridViewCircuitos.Rows.Add("Monza", "Italia", "5.79 km");
            dataGridViewCircuitos.Rows.Add("Le Mans", "Francia", "13.63 km");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad para agregar un circuito.", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCircuitos.SelectedRows.Count > 0)
            {
                dataGridViewCircuitos.Rows.RemoveAt(dataGridViewCircuitos.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Selecciona un circuito para eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewCircuitos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombreCircuito = dataGridViewCircuitos.Rows[e.RowIndex].Cells[0].Value.ToString();
                VerDetalleCircuito?.Invoke(nombreCircuito);
            }
        }
    }
}
