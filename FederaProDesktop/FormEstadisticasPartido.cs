using FederaProDesktop.Modelos.DTO;
using FederaProDesktop.Servicios.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop
{
    public partial class FormEstadisticasPartido : Form
    {
        private readonly PartidoDTO _partido;
        private readonly EstadisticasApiService _apiService = new EstadisticasApiService();
        private readonly JugadorApiService _jugadorApiService = new JugadorApiService();

        public FormEstadisticasPartido(PartidoDTO partido)
        {
            InitializeComponent();
            _partido = partido;
            InicializarEquiposPorNombreAsync(_partido.EquipoLocal, _partido.EquipoVisitante);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var estadisticasDTO = new EstadisticasPartidoDTO
                {
                    PartidoId = _partido.Id,
                    EstadisticasEquipos = new List<EstadisticaEquipoDTO>
                    {
                        new EstadisticaEquipoDTO
                        {
                            Equipo = _partido.EquipoLocal,
                            PartidoId = _partido.Id,
                            Puntos = (int)numPuntosLocal.Value,
                            Rebotes = (int)numRebotesLocal.Value,
                            Asistencias = (int)numAsistenciasLocal.Value,
                            Robos = (int)numRobosLocal.Value,
                            Tapones = (int)numTaponesLocal.Value,
                            Perdidas = (int)numPerdidasLocal.Value
                        },
                        new EstadisticaEquipoDTO
                        {
                            Equipo = _partido.EquipoVisitante,
                            PartidoId = _partido.Id,
                            Puntos = (int)numPuntosVisitante.Value,
                            Rebotes = (int)numRebotesVisitante.Value,
                            Asistencias = (int)numAsistenciasVisitante.Value,
                            Robos = (int)numRobosVisitante.Value,
                            Tapones = (int)numTaponesVisitante.Value,
                            Perdidas = (int)numPerdidasVisitante.Value
                        }
                    },
                    EstadisticasJugadores = new List<EstadisticaJugadorDTO>()
                };

                foreach (DataGridViewRow row in dgvEstadisticasJugadores.Rows)
                {
                    if (row.IsNewRow) continue;

                    var jugadorId = Convert.ToInt32(row.Cells["JugadorId"].Value);

                    estadisticasDTO.EstadisticasJugadores.Add(new EstadisticaJugadorDTO
                    {
                        IdJugador = jugadorId,
                        PartidoId = _partido.Id,
                        Puntos = Convert.ToInt32(row.Cells["Puntos"].Value ?? 0),
                        Rebotes = Convert.ToInt32(row.Cells["Rebotes"].Value ?? 0),
                        Asistencias = Convert.ToInt32(row.Cells["Asistencias"].Value ?? 0),
                        Robos = Convert.ToInt32(row.Cells["Robos"].Value ?? 0),
                        Tapones = Convert.ToInt32(row.Cells["Tapones"].Value ?? 0),
                        Perdidas = Convert.ToInt32(row.Cells["Perdidas"].Value ?? 0)
                    });
                }

                await _apiService.GuardarEstadisticasAsync(estadisticasDTO);
                MessageBox.Show("Estadísticas guardadas correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar estadísticas: " + ex.Message);
            }
        }

        private async Task InicializarEquiposPorNombreAsync(string nombreLocal, string nombreVisitante)
        {
            var equipoService = new EquipoApiService();
            var local = await equipoService.ObtenerEquipoPorNombreAsync(nombreLocal);
            var visitante = await equipoService.ObtenerEquipoPorNombreAsync(nombreVisitante);
            await CargarJugadoresEnTablaAsync(local.Id, visitante.Id);

            var estadisticas = await _apiService.ObtenerEstadisticasPorPartidoAsync(_partido.Id);

            if (estadisticas != null)
            {
                // Cargar estadísticas de equipo
                var estadisticaLocal = estadisticas.EstadisticasEquipos[0];
                var estadisticaVisitante = estadisticas.EstadisticasEquipos[1];

                numPuntosLocal.Value = estadisticaLocal.Puntos;
                numRebotesLocal.Value = estadisticaLocal.Rebotes;
                numAsistenciasLocal.Value = estadisticaLocal.Asistencias;
                numRobosLocal.Value = estadisticaLocal.Robos;
                numTaponesLocal.Value = estadisticaLocal.Tapones;
                numPerdidasLocal.Value = estadisticaLocal.Perdidas;

                numPuntosVisitante.Value = estadisticaVisitante.Puntos;
                numRebotesVisitante.Value = estadisticaVisitante.Rebotes;
                numAsistenciasVisitante.Value = estadisticaVisitante.Asistencias;
                numRobosVisitante.Value = estadisticaVisitante.Robos;
                numTaponesVisitante.Value = estadisticaVisitante.Tapones;
                numPerdidasVisitante.Value = estadisticaVisitante.Perdidas;

                // Cargar estadísticas de jugadores
                foreach (DataGridViewRow row in dgvEstadisticasJugadores.Rows)
                {
                    if (row.IsNewRow) continue;
                    var jugadorId = Convert.ToInt32(row.Cells["JugadorId"].Value);
                    var est = estadisticas.EstadisticasJugadores.FirstOrDefault(e => e.IdJugador == jugadorId);
                    if (est != null)
                    {
                        row.Cells["Puntos"].Value = est.Puntos;
                        row.Cells["Rebotes"].Value = est.Rebotes;
                        row.Cells["Asistencias"].Value = est.Asistencias;
                        row.Cells["Robos"].Value = est.Robos;
                        row.Cells["Tapones"].Value = est.Tapones;
                        row.Cells["Perdidas"].Value = est.Perdidas;
                    }
                }
            }
        }

        private async Task CargarJugadoresEnTablaAsync(int idLocal, int idVisitante)
        {
            var jugadoresLocal = await _jugadorApiService.ObtenerJugadoresPorEquipoAsync(idLocal);
            var jugadoresVisitante = await _jugadorApiService.ObtenerJugadoresPorEquipoAsync(idVisitante);

            var columnas = new[]
            {
                new DataGridViewTextBoxColumn { Name = "Jugador", HeaderText = "Jugador", ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "Puntos", HeaderText = "Puntos" },
                new DataGridViewTextBoxColumn { Name = "Rebotes", HeaderText = "Rebotes" },
                new DataGridViewTextBoxColumn { Name = "Asistencias", HeaderText = "Asistencias" },
                new DataGridViewTextBoxColumn { Name = "Robos", HeaderText = "Robos" },
                new DataGridViewTextBoxColumn { Name = "Tapones", HeaderText = "Tapones" },
                new DataGridViewTextBoxColumn { Name = "Perdidas", HeaderText = "Pérdidas" },
                new DataGridViewTextBoxColumn { Name = "JugadorId", Visible = false } // Oculto pero útil
            };

            dgvEstadisticasJugadores.Columns.Clear();
            dgvEstadisticasJugadores.Columns.AddRange(columnas);
            dgvEstadisticasJugadores.Rows.Clear();

            foreach (var jugador in jugadoresLocal.Concat(jugadoresVisitante))
            {
                dgvEstadisticasJugadores.Rows.Add(jugador.Nombre, 0, 0, 0, 0, 0, 0, jugador.Id);
            }
        }
    }
}

