using FederaProDesktop.Karting.DTOs;
using FederaProDesktop.Karting.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop.Karting
{
    public partial class DetalleCompeticionKarting : UserControl
    {
        private readonly string _nombreCompeticion;
        private readonly string _tipoCompeticion;
        private readonly KartingCompeticionApiService _api = new();
        private List<KartingCarreraDTO> _carrerasActuales = new();

        public DetalleCompeticionKarting(string nombre, string tipo)
        {
            InitializeComponent();
            _nombreCompeticion = nombre;
            _tipoCompeticion = tipo;

            lblTitulo.Text = $"{_nombreCompeticion} ({_tipoCompeticion})";
            _ = CargarCarrerasAsync();
        }

        private async Task CargarCarrerasAsync()
        {
            try
            {
                var carreras = await _api.ObtenerCarrerasDeCompeticionAsync(_nombreCompeticion);

                // Ordenamos por fecha y asignamos número dinámico
                _carrerasActuales = carreras
                    .OrderBy(c => c.Fecha)
                    .Select((c, index) => {
                        c.Numero = index + 1; // Asignamos número según orden
                        return c;
                    }).ToList();

                cboCarrera.Items.Clear();
                cboCarrera.Items.Add("Todas las carreras");

                foreach (var carrera in _carrerasActuales)
                {
                    cboCarrera.Items.Add($"Carrera {carrera.Numero}");
                }

                cboCarrera.SelectedIndex = 0;

                MostrarCarreras(_carrerasActuales);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar carreras: " + ex.Message);
            }
        }

        private void MostrarCarreras(List<KartingCarreraDTO> lista)
        {
            dgvCarreras.DataSource = null;
            dgvCarreras.DataSource = lista;

            dgvCarreras.Columns["Id"].Visible = false;

            if (dgvCarreras.Columns.Contains("Fecha"))
                dgvCarreras.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvCarreras.Columns.Contains("Circuito"))
                dgvCarreras.Columns["Circuito"].HeaderText = "Circuito";

            if (dgvCarreras.Columns.Contains("Numero"))
                dgvCarreras.Columns["Numero"].HeaderText = "Carrera Nº";
        }


        private void cboCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCarrera.SelectedIndex == 0)
            {
                MostrarCarreras(_carrerasActuales);
            }
            else
            {
                int numeroCarrera = cboCarrera.SelectedIndex;
                var filtradas = _carrerasActuales
                    .Where(c => c.Numero == numeroCarrera)
                    .ToList();
                MostrarCarreras(filtradas);
            }
        }

        private async void btnClasificacion_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(panelClasificacion);
            panelClasificacion.Visible = true;

            try
            {
                var pilotos = await _api.ObtenerClasificacionPilotosAsync(_nombreCompeticion);
                var equipos = await _api.ObtenerClasificacionEquiposAsync(_nombreCompeticion);

                dgvClasificacionPilotos.DataSource = pilotos;
                dgvClasificacionEquipos.DataSource = equipos;

                dgvClasificacionPilotos.Columns["Piloto"].HeaderText = "Piloto";
                dgvClasificacionPilotos.Columns["Equipo"].HeaderText = "Equipo";
                dgvClasificacionPilotos.Columns["Puntos"].HeaderText = "Pts";

                dgvClasificacionEquipos.Columns["Equipo"].HeaderText = "Equipo";
                dgvClasificacionEquipos.Columns["Puntos"].HeaderText = "Pts";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clasificación: " + ex.Message);
            }
        }

        private void btnCarreras_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(panelCarreras);
            panelCarreras.Visible = true;
        }

        private async void dgvCarreras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var carrera = (KartingCarreraDTO)dgvCarreras.Rows[e.RowIndex].DataBoundItem;

                try
                {
                    var apiPilotos = new PilotoApiService();
                    var pilotos = await apiPilotos.ObtenerPilotosPorCompeticionAsync(_nombreCompeticion);

                    var detalle = new FormEstadisticasCarrera(carrera, pilotos);
                    detalle.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los pilotos: " + ex.Message);
                }
            }
        }
        private async void btnAgregarCarrera_Click(object sender, EventArgs e)
        {
            var form = new CrearCarreraForm(_nombreCompeticion); // Le pasamos la competición actual
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                await CargarCarrerasAsync(); // Refrescamos la lista de carreras
            }
        }
    }
}