using FederaProDesktop.Karting.DTOs;
using FederaProDesktop.Karting.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop.Karting
{
    public partial class PilotosControl : UserControl
    {
        private readonly PilotoApiService _apiService = new();
        private readonly EquipoApiService _apiEquipoService = new();
        public event Action<string, string> VerDetallePiloto;
        private bool enModoEdicion = false;
        private DateTimePicker datePicker = new DateTimePicker();

        public PilotosControl()
        {
            InitializeComponent();
            ConfigurarColumnas();
            _ = CargarPilotosAsync();

            // Asociar el evento de edición para insertar el date picker
            dataGridViewPilotos.EditingControlShowing += dataGridViewPilotos_EditingControlShowing;
        }

        private void ConfigurarColumnas()
        {
            dataGridViewPilotos.Columns.Clear();

            dataGridViewPilotos.Columns.Add("Id", "ID");
            dataGridViewPilotos.Columns["Id"].Visible = false;

            dataGridViewPilotos.Columns.Add("Nombre", "Nombre");
            dataGridViewPilotos.Columns.Add("Nacionalidad", "Nacionalidad");
            dataGridViewPilotos.Columns.Add("FechaNacimiento", "Fecha Nacimiento");
            dataGridViewPilotos.Columns.Add("NumeroKart", "Nº Kart");
            dataGridViewPilotos.Columns.Add("Categoria", "Categoría");
            dataGridViewPilotos.Columns.Add("NombreEquipo", "Equipo");

            var btnGuardar = new DataGridViewButtonColumn
            {
                Name = "btnGuardar",
                HeaderText = "",
                Text = "Guardar",
                UseColumnTextForButtonValue = true,
                Visible = false
            };
            dataGridViewPilotos.Columns.Add(btnGuardar);

            var btnCancelar = new DataGridViewButtonColumn
            {
                Name = "btnCancelar",
                HeaderText = "",
                Text = "Cancelar",
                UseColumnTextForButtonValue = true,
                Visible = false
            };
            dataGridViewPilotos.Columns.Add(btnCancelar);
        }

        private void ActualizarVisibilidadBotones()
        {
            dataGridViewPilotos.Columns["btnGuardar"].Visible = enModoEdicion;
            dataGridViewPilotos.Columns["btnCancelar"].Visible = enModoEdicion;
        }

        private async Task CargarPilotosAsync()
        {
            try
            {
                var pilotos = await _apiService.ObtenerPilotosAsync();

                dataGridViewPilotos.Rows.Clear();
                foreach (var piloto in pilotos)
                {
                    dataGridViewPilotos.Rows.Add(
                        piloto.Id,
                        piloto.Nombre,
                        piloto.Nacionalidad,
                        piloto.FechaNacimiento?.ToString("yyyy-MM-dd"),
                        piloto.NumeroKart,
                        piloto.Categoria,
                        piloto.NombreEquipo
                    );
                }

                dataGridViewPilotos.ReadOnly = true;
                enModoEdicion = false;
                ActualizarVisibilidadBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pilotos: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dataGridViewPilotos.ReadOnly = false;

            dataGridViewPilotos.Rows.Add(
                0, "", "", DateTime.Now.ToString("yyyy-MM-dd"), 0, "", ""
            );

            var nuevaFila = dataGridViewPilotos.Rows[dataGridViewPilotos.RowCount - 1];
            nuevaFila.ReadOnly = false;
            dataGridViewPilotos.CurrentCell = nuevaFila.Cells["Nombre"];

            enModoEdicion = true;
            ActualizarVisibilidadBotones();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPilotos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un piloto para editar.");
                return;
            }

            var fila = dataGridViewPilotos.SelectedRows[0];
            fila.ReadOnly = false;
            dataGridViewPilotos.ReadOnly = false;

            enModoEdicion = true;
            ActualizarVisibilidadBotones();
        }

        private async void dataGridViewPilotos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columna = dataGridViewPilotos.Columns[e.ColumnIndex];
            var fila = dataGridViewPilotos.Rows[e.RowIndex];

            if (columna?.Name == "btnGuardar")
            {
                try
                {
                    var piloto = new KartingPiloto
                    {
                        Id = fila.Cells["Id"]?.Value != null ? Convert.ToInt32(fila.Cells["Id"].Value) : 0,
                        Nombre = fila.Cells["Nombre"]?.Value?.ToString() ?? "",
                        Nacionalidad = fila.Cells["Nacionalidad"]?.Value?.ToString() ?? "",
                        Categoria = fila.Cells["Categoria"]?.Value?.ToString() ?? "",
                        NombreEquipo = fila.Cells["NombreEquipo"]?.Value?.ToString() ?? ""
                    };

                    // FechaNacimiento
                    if (DateTime.TryParse(fila.Cells["FechaNacimiento"]?.Value?.ToString(), out DateTime fecha))
                        piloto.FechaNacimiento = fecha;
                    else
                        piloto.FechaNacimiento = null;

                    // NumeroKart
                    int.TryParse(fila.Cells["NumeroKart"]?.Value?.ToString(), out int numeroKart);
                    piloto.NumeroKart = numeroKart;

                    piloto.EquipoId = await ObtenerEquipoIdPorNombreAsync(piloto.NombreEquipo);
                    if (piloto.EquipoId == null)
                    {
                        MessageBox.Show("Equipo no encontrado o no especificado.");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(piloto.Nombre) || string.IsNullOrWhiteSpace(piloto.Categoria))
                    {
                        MessageBox.Show("Nombre y categoría son obligatorios.");
                        return;
                    }

                    if (piloto.Id == 0)
                        await _apiService.CrearPilotoAsync(piloto);
                    else
                        await _apiService.ActualizarPilotoAsync(piloto);

                    await CargarPilotosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
            else if (columna?.Name == "btnCancelar")
            {
                if (fila.Cells["Id"]?.Value == null || Convert.ToInt32(fila.Cells["Id"].Value) == 0)
                    dataGridViewPilotos.Rows.RemoveAt(e.RowIndex);
                else
                    await CargarPilotosAsync();
            }

            enModoEdicion = false;
            ActualizarVisibilidadBotones();
        }

        private void dataGridViewPilotos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewPilotos.CurrentCell.ColumnIndex == dataGridViewPilotos.Columns["FechaNacimiento"].Index)
            {
                e.Control.Visible = false;

                datePicker.Format = DateTimePickerFormat.Short;
                datePicker.Value = DateTime.TryParse(dataGridViewPilotos.CurrentCell.Value?.ToString(), out var dt) ? dt : DateTime.Now;
                datePicker.Visible = true;

                Rectangle rect = dataGridViewPilotos.GetCellDisplayRectangle(dataGridViewPilotos.CurrentCell.ColumnIndex, dataGridViewPilotos.CurrentCell.RowIndex, true);
                datePicker.Size = rect.Size;
                datePicker.Location = rect.Location;

                dataGridViewPilotos.Controls.Add(datePicker);
                datePicker.BringToFront();
                datePicker.Focus();

                datePicker.ValueChanged += (s, args) =>
                {
                    dataGridViewPilotos.CurrentCell.Value = datePicker.Value.ToString("yyyy-MM-dd");
                    datePicker.Visible = false;
                };
            }
            else
            {
                datePicker.Visible = false;
            }
        }

        private async Task<int?> ObtenerEquipoIdPorNombreAsync(string nombreEquipo)
        {
            if (string.IsNullOrWhiteSpace(nombreEquipo))
                return null;

            var equipos = await _apiEquipoService.ObtenerEquiposAsync();
            var equipo = equipos.FirstOrDefault(e => e.Nombre.Equals(nombreEquipo, StringComparison.OrdinalIgnoreCase));
            return equipo?.Id;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPilotos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un piloto para eliminar.");
                return;
            }

            var fila = dataGridViewPilotos.SelectedRows[0];
            int id = Convert.ToInt32(fila.Cells["Id"].Value);

            var confirm = MessageBox.Show("¿Eliminar este piloto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                await _apiService.EliminarPilotoAsync(id);
                await CargarPilotosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void dataGridViewPilotos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (enModoEdicion) return;

            if (e.RowIndex >= 0)
            {
                string nombre = dataGridViewPilotos.Rows[e.RowIndex].Cells["Nombre"]?.Value?.ToString();
                string categoria = dataGridViewPilotos.Rows[e.RowIndex].Cells["Categoria"]?.Value?.ToString();

                VerDetallePiloto?.Invoke(nombre, categoria);
            }
        }
    }
}