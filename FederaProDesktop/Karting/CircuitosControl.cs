using FederaProDesktop.Karting.DTOs;
using FederaProDesktop.Karting.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop.Karting
{
    public partial class CircuitosControl : UserControl
    {
        private readonly CircuitoApiService _apiService = new();
        private bool enModoEdicion = false;

        public CircuitosControl()
        {
            InitializeComponent();
            ConfigurarColumnas();
            _ = CargarCircuitosAsync();
        }

        private void ConfigurarColumnas()
        {
            dataGridViewCircuitos.Columns.Clear();

            dataGridViewCircuitos.Columns.Add("Id", "ID");
            dataGridViewCircuitos.Columns["Id"].Visible = false;

            dataGridViewCircuitos.Columns.Add("Nombre", "Nombre");
            dataGridViewCircuitos.Columns.Add("Ubicacion", "Ubicación");
            dataGridViewCircuitos.Columns.Add("Longitud", "Longitud (km)");
            dataGridViewCircuitos.Columns.Add("Pais", "País");

            var btnGuardar = new DataGridViewButtonColumn
            {
                Name = "btnGuardar",
                HeaderText = "",
                Text = "Guardar",
                UseColumnTextForButtonValue = true,
                Visible = false
            };
            dataGridViewCircuitos.Columns.Add(btnGuardar);

            var btnCancelar = new DataGridViewButtonColumn
            {
                Name = "btnCancelar",
                HeaderText = "",
                Text = "Cancelar",
                UseColumnTextForButtonValue = true,
                Visible = false
            };
            dataGridViewCircuitos.Columns.Add(btnCancelar);
        }

        private async Task CargarCircuitosAsync()
        {
            try
            {
                var circuitos = await _apiService.ObtenerCircuitosAsync();
                dataGridViewCircuitos.Rows.Clear();

                foreach (var c in circuitos)
                {
                    dataGridViewCircuitos.Rows.Add(
                        c.Id,
                        c.Nombre,
                        c.Ubicacion,
                        c.Longitud,
                        c.Pais
                    );
                }

                dataGridViewCircuitos.ReadOnly = true;
                enModoEdicion = false;
                ActualizarBotonesAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar circuitos: " + ex.Message);
            }
        }

        private void ActualizarBotonesAccion()
        {
            dataGridViewCircuitos.Columns["btnGuardar"].Visible = enModoEdicion;
            dataGridViewCircuitos.Columns["btnCancelar"].Visible = enModoEdicion;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dataGridViewCircuitos.ReadOnly = false;

            dataGridViewCircuitos.Rows.Add(0, "", "", 0.00m, "");

            var nuevaFila = dataGridViewCircuitos.Rows[dataGridViewCircuitos.RowCount - 1];
            nuevaFila.ReadOnly = false;
            dataGridViewCircuitos.CurrentCell = nuevaFila.Cells["Nombre"];

            enModoEdicion = true;
            ActualizarBotonesAccion();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCircuitos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un circuito para editar.");
                return;
            }

            var fila = dataGridViewCircuitos.SelectedRows[0];
            fila.ReadOnly = false;
            dataGridViewCircuitos.ReadOnly = false;

            enModoEdicion = true;
            ActualizarBotonesAccion();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCircuitos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un circuito para eliminar.");
                return;
            }

            var fila = dataGridViewCircuitos.SelectedRows[0];
            int id = Convert.ToInt32(fila.Cells["Id"].Value);

            var confirm = MessageBox.Show("¿Eliminar este circuito?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                await _apiService.EliminarCircuitoAsync(id);
                await CargarCircuitosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private async void dataGridViewCircuitos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columna = dataGridViewCircuitos.Columns[e.ColumnIndex];
            var fila = dataGridViewCircuitos.Rows[e.RowIndex];

            if (columna?.Name == "btnGuardar")
            {
                try
                {
                    var circuito = new KartingCircuito
                    {
                        Id = fila.Cells["Id"]?.Value != null ? Convert.ToInt32(fila.Cells["Id"].Value) : 0,
                        Nombre = fila.Cells["Nombre"]?.Value?.ToString() ?? "",
                        Ubicacion = fila.Cells["Ubicacion"]?.Value?.ToString() ?? "",
                        Pais = fila.Cells["Pais"]?.Value?.ToString() ?? ""
                    };

                    decimal.TryParse(fila.Cells["Longitud"]?.Value?.ToString(), out decimal longitud);
                    circuito.Longitud = longitud;

                    if (string.IsNullOrWhiteSpace(circuito.Nombre))
                    {
                        MessageBox.Show("El nombre es obligatorio.");
                        return;
                    }

                    if (circuito.Id == 0)
                        await _apiService.CrearCircuitoAsync(circuito);
                    else
                        await _apiService.ActualizarCircuitoAsync(circuito);

                    await CargarCircuitosAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
            else if (columna?.Name == "btnCancelar")
            {
                if (fila.Cells["Id"]?.Value == null || Convert.ToInt32(fila.Cells["Id"].Value) == 0)
                    dataGridViewCircuitos.Rows.RemoveAt(e.RowIndex);
                else
                    await CargarCircuitosAsync();
            }

            enModoEdicion = false;
            ActualizarBotonesAccion();
        }
    }
}