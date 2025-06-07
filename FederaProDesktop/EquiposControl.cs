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
    public partial class EquiposControl : UserControl
    {

        public event Action<BasketEquipoDTO> VerDetalleEquipo;
        private readonly EquipoApiService _apiService = new EquipoApiService();

        public EquiposControl()
        {
            InitializeComponent();
            ConfigurarComponentes();
            _ = CargarEquiposAsync();
        }

        private void ConfigurarComponentes()
        {
            // Simula placeholders sin PlaceholderText (.NET Framework)
            PrepararPlaceholder(txtNombre, "Nombre del equipo");
            PrepararPlaceholder(txtCiudad, "Ciudad");
        }

        private async Task CargarEquiposAsync()
        {
            try
            {
                dgvEquipos.DataSource = null;
                var equipos = await _apiService.GetEquiposAsync();
                dgvEquipos.DataSource = equipos;

                // Opcional: ocultar columnas no deseadas
                dgvEquipos.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar equipos: " + ex.Message);
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

        private void dgvEquipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var equipo = (BasketEquipoDTO)dgvEquipos.Rows[e.RowIndex].DataBoundItem;
                VerDetalleEquipo?.Invoke(equipo);
            }
        }
        private async void btnCSV_Click(object sender, EventArgs e)
        {
            using var openDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _apiService.CargarEquiposDesdeCSVAsync(openDialog.FileName);
                    MessageBox.Show("Equipos cargados correctamente.");
                    await CargarEquiposAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar CSV: " + ex.Message);
                }
            }
        }

        private async void btnDescargarCSV_Click(object sender, EventArgs e)
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "plantilla_equipos.csv"
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
