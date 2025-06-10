using FederaProDesktop.Karting.DTOs;
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
        private readonly EquipoApiService _apiEquipoService = new();
        private bool enModoEdicion = false;

        public EquiposKartingControl()
        {
            InitializeComponent();
            InicializarColumnas();
            CargarEquipos();
        }

        private async void CargarEquipos()
        {
            var equipos = await _apiEquipoService.ObtenerEquiposAsync();

            dataGridViewEquipos.Rows.Clear();

            foreach (var equipo in equipos)
            {
                dataGridViewEquipos.Rows.Add(equipo.Id, equipo.Nombre, equipo.Pais, equipo.Sponsor);
            }
        }

        private void InicializarColumnas()
        {
            dataGridViewEquipos.Columns.Clear();
            dataGridViewEquipos.AutoGenerateColumns = false;

            dataGridViewEquipos.Columns.Add("Id", "Id");
            dataGridViewEquipos.Columns["Id"].Visible = false;

            dataGridViewEquipos.Columns.Add("Nombre", "Nombre");
            dataGridViewEquipos.Columns.Add("Pais", "País");
            dataGridViewEquipos.Columns.Add("Sponsor", "Sponsor");

            var btnGuardar = new DataGridViewButtonColumn
            {
                Name = "btnGuardar",
                HeaderText = "",
                Text = "Guardar",
                UseColumnTextForButtonValue = true
            };
            dataGridViewEquipos.Columns.Add(btnGuardar);

            var btnCancelar = new DataGridViewButtonColumn
            {
                Name = "btnCancelar",
                HeaderText = "",
                Text = "Cancelar",
                UseColumnTextForButtonValue = true
            };
            dataGridViewEquipos.Columns.Add(btnCancelar);
            ActualizarVisibilidadBotones();
        }

        private void ActualizarVisibilidadBotones()
        {
            dataGridViewEquipos.Columns["btnGuardar"].Visible = enModoEdicion;
            dataGridViewEquipos.Columns["btnCancelar"].Visible = enModoEdicion;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dataGridViewEquipos.Rows.Add(0, "", "", "", "Guardar", "Cancelar");

            var fila = dataGridViewEquipos.Rows[dataGridViewEquipos.RowCount - 1];
            fila.ReadOnly = false;
            dataGridViewEquipos.CurrentCell = fila.Cells["Nombre"];

            enModoEdicion = true;
            ActualizarVisibilidadBotones();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewEquipos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un equipo para editar.");
                return;
            }

            var fila = dataGridViewEquipos.SelectedRows[0];
            fila.ReadOnly = false;

            enModoEdicion = true;
            ActualizarVisibilidadBotones();
        }

        private async void dataGridViewEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columna = dataGridViewEquipos.Columns[e.ColumnIndex];
            var fila = dataGridViewEquipos.Rows[e.RowIndex];

            if (columna.Name == "btnGuardar")
            {
                try
                {
                    int id = Convert.ToInt32(fila.Cells["Id"].Value ?? 0);
                    string nombre = fila.Cells["Nombre"].Value?.ToString() ?? "";
                    string pais = fila.Cells["Pais"].Value?.ToString() ?? "";
                    string sponsor = fila.Cells["Sponsor"].Value?.ToString() ?? "";

                    if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(pais))
                    {
                        MessageBox.Show("Nombre y país son obligatorios.");
                        return;
                    }

                    var equipo = new KartingEquipo
                    {
                        Id = id,
                        Nombre = nombre,
                        Pais = pais,
                        Sponsor = sponsor
                    };

                    if (id == 0)
                        await _apiEquipoService.CrearEquipoAsync(equipo);
                    else
                        await _apiEquipoService.ActualizarEquipoAsync(equipo);

                    await Task.Delay(200); // por seguridad en sincronización
                    CargarEquipos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
            else if (columna.Name == "btnCancelar")
            {
                int id = Convert.ToInt32(fila.Cells["Id"].Value ?? 0);
                if (id == 0)
                    dataGridViewEquipos.Rows.RemoveAt(e.RowIndex);
                else
                    CargarEquipos();
            }

            enModoEdicion = false;
            ActualizarVisibilidadBotones();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if(enModoEdicion)
            {
                MessageBox.Show("No se puede eliminar en modo edición");
                return;
            }
            if (dataGridViewEquipos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un equipo para eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dataGridViewEquipos.SelectedRows[0];
            int id = Convert.ToInt32(fila.Cells["Id"].Value);

            var confirm = MessageBox.Show("¿Estás seguro de que deseas eliminar este equipo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                await _apiEquipoService.EliminarEquipoAsync(id);
                CargarEquipos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void dataGridViewEquipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (enModoEdicion) return;
            if (e.RowIndex >= 0)
            {
                string nombreEquipo = dataGridViewEquipos.Rows[e.RowIndex].Cells[1].Value.ToString();
                string paisEquipo = dataGridViewEquipos.Rows[e.RowIndex].Cells[2].Value.ToString();
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
