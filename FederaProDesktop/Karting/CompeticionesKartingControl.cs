using FederaProDesktop.Karting.DTOs;
using FederaProDesktop.Karting.Servicios;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop.Karting
{
    public partial class CompeticionesKartingControl : UserControl
    {
        private readonly KartingCompeticionApiService competicionService = new KartingCompeticionApiService();

        public event Action<string, string> VerDetalleCompeticion;

        public CompeticionesKartingControl()
        {
            InitializeComponent();
            _ = CargarCompeticionesDesdeApiAsync();
        }

        private async Task CargarCompeticionesDesdeApiAsync()
        {
            try
            {
                var competiciones = await competicionService.GetAllCompeticionesAsync();

                dataGridViewCompeticiones.Rows.Clear();
                foreach (var comp in competiciones)
                {
                    dataGridViewCompeticiones.Rows.Add(comp.Nombre, comp.Temporada);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar competiciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad para agregar competición.", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCompeticiones.SelectedRows.Count > 0)
            {
                dataGridViewCompeticiones.Rows.RemoveAt(dataGridViewCompeticiones.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Selecciona una competición para eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewCompeticiones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombre = dataGridViewCompeticiones.Rows[e.RowIndex].Cells[0].Value.ToString();
                string temporada = dataGridViewCompeticiones.Rows[e.RowIndex].Cells[1].Value.ToString();
                VerDetalleCompeticion?.Invoke(nombre, temporada);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var competiciones = await competicionService.GetAllCompeticionesAsync();
                dataGridViewCompeticiones.Rows.Clear();
                dataGridViewCompeticiones.Columns.Clear();

                dataGridViewCompeticiones.Columns.Add("Nombre", "Nombre");
                dataGridViewCompeticiones.Columns.Add("Temporada", "Temporada");

                foreach (var comp in competiciones)
                {
                    dataGridViewCompeticiones.Rows.Add(comp.Nombre, comp.Temporada);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las competiciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}