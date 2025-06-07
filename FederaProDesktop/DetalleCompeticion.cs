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
    public partial class DetalleCompeticion : UserControl
    {
        private string nombreCompeticionActual;
        private List<PartidoDTO> partidosActuales = new List<PartidoDTO>();

        public DetalleCompeticion(string nombreCompeticion, string tipoCompeticion)
        {
            InitializeComponent();
            nombreCompeticionActual = nombreCompeticion;
            CargarPartidosAsync();
            lblTitulo.Text = $"{nombreCompeticion} ({tipoCompeticion})";
        }

        private async void btnClasificacion_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(panelClasificacion);
            panelClasificacion.Visible = true;

            try
            {
                var api = new BasketCompeticionApi();
                var clasificacion = await api.ObtenerClasificacionAsync(nombreCompeticionActual);

                dgvClasificacion.DataSource = null;
                dgvClasificacion.DataSource = clasificacion;

                dgvClasificacion.Columns["NombreEquipo"].HeaderText = "Equipo";
                dgvClasificacion.Columns["PartidosJugados"].HeaderText = "PJ";
                dgvClasificacion.Columns["Victorias"].HeaderText = "V";
                dgvClasificacion.Columns["Derrotas"].HeaderText = "D";
                dgvClasificacion.Columns["Puntos"].HeaderText = "Pts";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la clasificación: " + ex.Message);
            }
        }

        private async void btnGenerarPartidos_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Estás seguro de que deseas generar los partidos automáticamente para esta competición?",
                "Confirmar generación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                // Llamada a la API para generar partidos
                var api = new BasketCompeticionApi();
                await api.GenerarPartidosAsync(lblTitulo.Text.Split('(')[0].Trim());

                MessageBox.Show("Partidos generados con éxito.");
                // Aquí puedes recargar la lista de partidos si ya tienes implementado ese método.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar los partidos: " + ex.Message);
            }
        }

        private void btnPartidos_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(panelPartidos);
            panelPartidos.Visible = true;
        }

        private async void CargarPartidosAsync()
        {
            try
            {
                var api = new BasketCompeticionApi();
                partidosActuales = await api.GetPartidosDeCompeticionAsync(nombreCompeticionActual);

                // Ocultar botón si ya hay partidos generados
                btnGenerarPartidos.Visible = partidosActuales == null || partidosActuales.Count == 0;

                LlenarComboJornadas();
                MostrarPartidos(partidosActuales);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los partidos: " + ex.Message);
            }
        }

        private void LlenarComboJornadas()
        {
            cboJornada.Items.Clear();
            cboJornada.Items.Add("Todos los partidos");

            var jornadas = partidosActuales
                .Select(p => p.Jornada)
                .Distinct()
                .OrderBy(j => j)
                .ToList();

            foreach (var j in jornadas)
                cboJornada.Items.Add($"Jornada {j}");

            cboJornada.SelectedIndex = 0;
        }

        private void cboJornada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboJornada.SelectedIndex == 0)
            {
                MostrarPartidos(partidosActuales);
            }
            else
            {
                int jornadaSeleccionada = cboJornada.SelectedIndex; // 1-based
                var filtrados = partidosActuales
                    .Where(p => p.Jornada == jornadaSeleccionada)
                    .ToList();

                MostrarPartidos(filtrados);
            }
        }
        private void MostrarPartidos(List<PartidoDTO> lista)
        {
            dgvPartidos.DataSource = null;
            dgvPartidos.DataSource = lista;

            if (dgvPartidos.Columns.Contains("Id"))
                dgvPartidos.Columns["Id"].Visible = false;
        }
        private void dgvPartidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvPartidos.Rows.Count)
            {
                var partido = (PartidoDTO)dgvPartidos.Rows[e.RowIndex].DataBoundItem;

                var formularioEstadisticas = new FormEstadisticasPartido(partido);
                formularioEstadisticas.ShowDialog();
            }
        }
    }
}
