using FederaProDesktop.Karting.Servicios;
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
    public partial class PilotosControl : UserControl
    {
        public event Action<string, string> VerDetallePiloto;

        public PilotosControl()
        {
            InitializeComponent();
            CargarPilotos();
        }

        private async void CargarPilotos()
        {
            var apiService = new PilotoApiService();
            var pilotos = await apiService.ObtenerPilotosAsync();

            dataGridViewPilotos.Rows.Clear();

            foreach (var piloto in pilotos)
            {
                dataGridViewPilotos.Rows.Add(piloto.Nombre, piloto.Nacionalidad, piloto.Edad, piloto.Categoria);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad para agregar un piloto.", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPilotos.SelectedRows.Count > 0)
            {
                dataGridViewPilotos.Rows.RemoveAt(dataGridViewPilotos.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Selecciona un piloto para eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewPilotos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombrePiloto = dataGridViewPilotos.Rows[e.RowIndex].Cells[0].Value.ToString();
                string categoriaPiloto = dataGridViewPilotos.Rows[e.RowIndex].Cells[1].Value.ToString(); // Asegúrate de que la categoría esté en la columna 1

                VerDetallePiloto?.Invoke(nombrePiloto, categoriaPiloto);
            }
        }
    }
}
