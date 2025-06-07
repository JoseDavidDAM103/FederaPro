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
    public partial class JugadoresControl : UserControl
    {
        private readonly JugadorApiService _apiService = new JugadorApiService();
        public event Action<string, string> VerDetalleJugador;
        public JugadoresControl()
        {
            InitializeComponent();
            ConfigurarComponentes();
            CargarJugadoresAsync();
        }

        private void ConfigurarComponentes()
        {
            PrepararPlaceholder(txtNombre, "Nombre del jugador");
            PrepararPlaceholder(txtDorsal, "Dorsal");
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
        private void dgvJugadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombre = dgvJugadores.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                string posicion = dgvJugadores.Rows[e.RowIndex].Cells["Posicion"].Value.ToString();

                VerDetalleJugador?.Invoke(nombre, posicion);
            }
        }
        private async void btnDescargarCSV_Click(object sender, EventArgs e)
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "plantilla_jugadores.csv"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _apiService.DescargarPlantillaCSVAsync(saveDialog.FileName);
                    MessageBox.Show("Plantilla descargada correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al descargar plantilla: " + ex.Message);
                }
            }
        }
    }
}
