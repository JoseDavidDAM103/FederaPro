using FederaProDesktop.Modelos.DTO;
using FederaProDesktop.Servicios.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop
{
    public partial class DetalleEquipoControl : UserControl
    {
        private readonly BasketEquipoDTO _equipo;
        private readonly JugadorApiService _jugadorApiService = new JugadorApiService();
        private readonly EquipoApiService _equipoApiService = new EquipoApiService();

        public DetalleEquipoControl(BasketEquipoDTO equipo)
        {
            InitializeComponent();
            _equipo = equipo;
            lblTitulo.Text = $"{equipo.Nombre} | Ciudad: {equipo.Ciudad}";
        }

        private async void btnJugadores_Click(object sender, EventArgs e)
        {
            panelContenido.Visible = false;
            panelJugadores.Visible = true;
            await CargarJugadoresAsync();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            CargarContenido(new Label { Text = "Estadísticas por partido...", AutoSize = true });
        }

        private async void btnPartidos_Click(object sender, EventArgs e)
        {
            panelJugadores.Visible = false;
            panelContenido.Visible = true;
            panelPartidos.Visible = true;

            await CargarPartidosDelEquipoAsync();
        }

        private async Task CargarPartidosDelEquipoAsync()
        {
            try
            {

                var partidos = await _equipoApiService.GetPartidosDelEquipoAsync(_equipo.Id); // asumiendo que lo pasas desde fuera

                dgvPartidos.DataSource = partidos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los partidos del equipo: " + ex.Message);
            }
        }

        private void CargarContenido(Control control)
        {
            panelContenido.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }
        private async Task CargarJugadoresAsync()
        {
            try
            {
                var jugadores = await _jugadorApiService.ObtenerJugadoresPorEquipoAsync(_equipo.Id);
                dgvJugadores.DataSource = jugadores;

                if (dgvJugadores.Columns.Contains("Id"))
                    dgvJugadores.Columns["Id"].Visible = false;

                if (dgvJugadores.Columns.Contains("Equipo"))
                {
                    dgvJugadores.Columns["Equipo"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar jugadores: " + ex.Message);
            }
        }
        private async void btnImportarJugadoresCsv_Click(object sender, EventArgs e)
        {
            using var openDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _jugadorApiService.CargarJugadoresDesdeCsvAsync(openDialog.FileName, _equipo);
                    MessageBox.Show("Jugadores importados correctamente.");
                    await CargarJugadoresAsync(); // refrescar tabla
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al importar jugadores: " + ex.Message);
                }
            }
        }
    }
}

