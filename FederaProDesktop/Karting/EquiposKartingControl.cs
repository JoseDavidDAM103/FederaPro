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
    public partial class EquiposKartingControl : UserControl
    {
        public event Action<string, string> VerDetalleEquipo;

        public EquiposKartingControl()
        {
            InitializeComponent();
            CargarEquipos();
        }

        private async void CargarEquipos()
        {
            var api = new EquipoApiService();
            var equipos = await api.ObtenerEquiposAsync();

            dataGridViewEquipos.Rows.Clear();

            if (dataGridViewEquipos.Columns.Count == 0)
            {
                dataGridViewEquipos.Columns.Add("Nombre", "Nombre");
                dataGridViewEquipos.Columns.Add("Pais", "País");
                dataGridViewEquipos.Columns.Add("Sponsor", "Sponsor");
            }

            foreach (var equipo in equipos)
            {
                dataGridViewEquipos.Rows.Add(equipo.Nombre, equipo.Pais, equipo.Sponsor);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad para agregar un equipo.", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewEquipos.SelectedRows.Count > 0)
            {
                dataGridViewEquipos.Rows.RemoveAt(dataGridViewEquipos.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Selecciona un equipo para eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewEquipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombreEquipo = dataGridViewEquipos.Rows[e.RowIndex].Cells[0].Value.ToString();
                string paisEquipo = dataGridViewEquipos.Rows[e.RowIndex].Cells[1].Value.ToString();
                VerDetalleEquipo?.Invoke(nombreEquipo, paisEquipo);
            }
        }
        private async void btnDescargarPlantilla_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV files (*.csv)|*.csv";
                dialog.Title = "Guardar plantilla de equipos de karting";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var api = new EquipoApiService();
                    try
                    {
                        await api.DescargarCSVAsync(dialog.FileName);
                        MessageBox.Show("Plantilla descargada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al descargar plantilla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void btnImportarCSV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "CSV files (*.csv)|*.csv";
                dialog.Title = "Importar equipos desde CSV";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var api = new EquipoApiService();
                    try
                    {
                        await api.ImportarCSVAsync(dialog.FileName);
                        MessageBox.Show("Importación completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarEquipos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al importar CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
