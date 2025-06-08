using FederaProDesktop.Karting.DTOs;
using FederaProDesktop.Karting.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FederaProDesktop.Karting
{
    public partial class FormEstadisticasCarrera : Form
    {
        private readonly KartingCarreraDTO carrera;
        private readonly List<KartingPiloto> pilotos;
        private readonly EstadisticasCarreraApiService apiService = new();

        public FormEstadisticasCarrera(KartingCarreraDTO carrera, List<KartingPiloto> pilotos)
        {
            InitializeComponent();
            this.carrera = carrera;
            this.pilotos = pilotos;

            lblTitulo.Text = $"Estadísticas - {carrera.Circuito} - {carrera.Fecha.ToShortDateString()}";
            InicializarTabla();
            CargarPilotosEnTabla();
        }

        private void InicializarTabla()
        {
            dgvEstadisticas.Columns.Clear();
            dgvEstadisticas.Rows.Clear();

            dgvEstadisticas.Columns.Add("colNombre", "Piloto");
            dgvEstadisticas.Columns.Add("colPosicion", "Posición");
            dgvEstadisticas.Columns.Add("colTiempoTotal", "Tiempo Total");
            dgvEstadisticas.Columns.Add("colVueltas", "Vueltas");

            dgvEstadisticas.Columns["colNombre"].ReadOnly = true;
            dgvEstadisticas.Columns["colNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CargarPilotosEnTabla()
        {
            foreach (var piloto in pilotos)
            {
                dgvEstadisticas.Rows.Add(piloto.Nombre);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var listaEstadisticas = new List<KartingEstadisticaPilotoDTO>();

            foreach (DataGridViewRow row in dgvEstadisticas.Rows)
            {
                if (row.IsNewRow) continue;

                string nombre = row.Cells["colNombre"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(nombre)) continue;

                var estadistica = new KartingEstadisticaPilotoDTO
                {
                    NombrePiloto = nombre,
                    IdCarrera = carrera.Id,
                    Posicion = TryParseInt(row.Cells["colPosicion"].Value) ?? 0,
                    TiempoTotal = TryParseDecimal(row.Cells["colTiempoTotal"].Value) ?? 0,
                    Vueltas = TryParseInt(row.Cells["colVueltas"].Value) ?? 0
                };

                listaEstadisticas.Add(estadistica);
            }

            bool exito = await apiService.GuardarEstadisticasAsync(listaEstadisticas);
            if (exito)
            {
                MessageBox.Show("Estadísticas guardadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar las estadísticas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? TryParseInt(object value)
        {
            return int.TryParse(value?.ToString(), out int result) ? result : (int?)null;
        }

        private decimal? TryParseDecimal(object value)
        {
            return decimal.TryParse(value?.ToString(), out decimal result) ? result : (decimal?)null;
        }
    }
}
