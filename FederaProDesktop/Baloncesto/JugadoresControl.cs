using FederaProDesktop.Modelos.DTO;
using FederaProDesktop.Servicios.Api;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop
{
    public partial class JugadoresControl : UserControl
    {
        private readonly JugadorApiService _apiService = new JugadorApiService();
        public event Action<string, string> VerDetalleJugador;

        public JugadoresControl()
        {
            InitializeComponent();
            ConfigurarComponentes();
            InicializarColumnasAccion();
            _ = CargarJugadoresAsync();
        }

        private void ConfigurarComponentes()
        {
            PrepararPlaceholder(txtNombre, "Nombre del jugador");
            PrepararPlaceholder(txtEquipo, "Equipo");
            PrepararPlaceholder(txtPosicion, "Posición");
        }

        private async Task CargarJugadoresAsync()
        {
            try
            {
                dgvJugadores.DataSource = null;
                var jugadores = await _apiService.GetJugadoresAsync();
                dgvJugadores.DataSource = jugadores;

                dgvJugadores.Columns["Id"].Visible = false;
                if (dgvJugadores.Columns.Contains("Equipo"))
                    dgvJugadores.Columns["Equipo"].Visible = false;

                OcultarColumnasAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar jugadores: " + ex.Message);
            }
        }

        private void PrepararPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        private void InicializarColumnasAccion()
        {
            if (!dgvJugadores.Columns.Contains("btnGuardar"))
            {
                var btnGuardar = new DataGridViewButtonColumn
                {
                    Name = "btnGuardar",
                    HeaderText = "",
                    Text = "Guardar",
                    UseColumnTextForButtonValue = true,
                    Visible = false
                };
                dgvJugadores.Columns.Add(btnGuardar);
            }

            if (!dgvJugadores.Columns.Contains("btnCancelar"))
            {
                var btnCancelar = new DataGridViewButtonColumn
                {
                    Name = "btnCancelar",
                    HeaderText = "",
                    Text = "Cancelar",
                    UseColumnTextForButtonValue = true,
                    Visible = false
                };
                dgvJugadores.Columns.Add(btnCancelar);
            }
        }

        private void OcultarColumnasAccion()
        {
            dgvJugadores.Columns["btnGuardar"].Visible = false;
            dgvJugadores.Columns["btnCancelar"].Visible = false;
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            var jugadores = dgvJugadores.DataSource as List<BasketJugadoreDTO>;
            dgvJugadores.DataSource = null;

            var lista = jugadores != null ? new List<BasketJugadoreDTO>(jugadores) : new List<BasketJugadoreDTO>();

            lista.Add(new BasketJugadoreDTO
            {
                Id = 0,
                Nombre = "",
                Posicion = "",
                Altura = 0,
                Peso = 0,
                Dorsal = 0,
                Equipo = new BasketEquipoDTO { Nombre = "" }
            });

            dgvJugadores.DataSource = lista;

            dgvJugadores.Columns["Id"].Visible = false;
            if (dgvJugadores.Columns.Contains("Equipo"))
                dgvJugadores.Columns["Equipo"].Visible = false;

            dgvJugadores.Columns["btnGuardar"].Visible = true;
            dgvJugadores.Columns["btnCancelar"].Visible = true;

            var nuevaFila = dgvJugadores.Rows[dgvJugadores.RowCount - 1];
            nuevaFila.ReadOnly = false;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvJugadores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una fila para editar.");
                return;
            }

            var fila = dgvJugadores.SelectedRows[0];
            fila.ReadOnly = false;

            dgvJugadores.Columns["btnGuardar"].Visible = true;
            dgvJugadores.Columns["btnCancelar"].Visible = true;
        }

        private async void dgvJugadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var columna = dgvJugadores.Columns[e.ColumnIndex];
            var fila = dgvJugadores.Rows[e.RowIndex];

            if (columna.Name == "btnGuardar")
            {
                int id = Convert.ToInt32(fila.Cells["Id"].Value);
                string nombre = fila.Cells["Nombre"].Value?.ToString();
                string posicion = fila.Cells["Posicion"].Value?.ToString();
                string nombreEquipo = fila.Cells["NombreEquipo"].Value?.ToString();
                double.TryParse(fila.Cells["Altura"].Value?.ToString(), out double altura);
                double.TryParse(fila.Cells["Peso"].Value?.ToString(), out double peso);
                int.TryParse(fila.Cells["Dorsal"].Value?.ToString(), out int dorsal);

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(posicion))
                {
                    MessageBox.Show("Nombre y posición son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    int? equipoId = await _apiService.ObtenerEquipoIdPorNombreAsync(nombreEquipo);
                    if (equipoId == null)
                    {
                        MessageBox.Show("Equipo no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (id != 0)
                    {
                        var jugador = new CrearActualizarJugadorDTO { id = id, nombre = nombre, posicion = posicion, altura = altura, peso = peso, dorsal = dorsal, equipoId = equipoId.Value };
                        await _apiService.ActualizarJugadorAsync(jugador);
                    }
                    else
                    {
                        var jugador = new CrearActualizarJugadorDTO { nombre = nombre, posicion = posicion, altura = altura, peso = peso, dorsal = dorsal, equipoId = equipoId.Value };
                        await _apiService.CrearJugadorAsync(jugador);
                    }

                    await CargarJugadoresAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
            else if (columna.Name == "btnCancelar")
            {
                if (fila.Cells["Id"].Value == null)
                    dgvJugadores.Rows.RemoveAt(e.RowIndex);
                else
                    await CargarJugadoresAsync();
            }
        }

        private void dgvJugadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombre = dgvJugadores.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                string posicion = dgvJugadores.Rows[e.RowIndex].Cells["Posicion"].Value.ToString();

                VerDetalleJugador?.Invoke(nombre, posicion);
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreJugador = txtNombre.ForeColor == Color.Gray ? "" : txtNombre.Text.Trim();
            string nombreEquipo = txtEquipo.ForeColor == Color.Gray ? "" : txtEquipo.Text.Trim();
            string posicion = txtPosicion.ForeColor == Color.Gray ? "" : txtPosicion.Text.Trim();

            try
            {
                dgvJugadores.DataSource = null;
                var jugadores = await _apiService.BuscarJugadoresAsync(nombreJugador, nombreEquipo, posicion);

                if (jugadores == null || jugadores.Count == 0)
                {
                    MessageBox.Show("No se encontraron jugadores con los filtros aplicados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dgvJugadores.DataSource = jugadores;

                dgvJugadores.Columns["Id"].Visible = false;
                if (dgvJugadores.Columns.Contains("Equipo"))
                    dgvJugadores.Columns["Equipo"].Visible = false;

                if (dgvJugadores.Columns.Contains("Equipo"))
                    dgvJugadores.Columns["Equipo"].Visible = false;

                OcultarColumnasAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar jugadores: " + ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvJugadores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un jugador para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("¿Estás seguro de que deseas eliminar este jugador?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var fila = dgvJugadores.SelectedRows[0];
                int jugadorId = Convert.ToInt32(fila.Cells["Id"].Value);

                await _apiService.EliminarJugadorAsync(jugadorId);
                MessageBox.Show("Jugador eliminado correctamente.");

                await CargarJugadoresAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar jugador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}