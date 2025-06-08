using FederaProDesktop.Karting.DTOs;
using FederaProDesktop.Karting.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FederaProDesktop.Karting
{
    public partial class CrearCarreraForm : Form
    {
        private readonly string _nombreCompeticion;
        private readonly CircuitoApiService _circuitoApi = new();
        private readonly KartingCarreraApiService _carreraApi = new();

        private List<KartingCircuito> _circuitos = new();

        public CrearCarreraForm(string nombreCompeticion)
        {
            InitializeComponent();
            _nombreCompeticion = nombreCompeticion;
        }

        private async void CrearCarreraForm_Load(object sender, EventArgs e)
        {
            try
            {
                _circuitos = await _circuitoApi.ObtenerCircuitosAsync();
                cboCircuito.Items.Clear();
                foreach (var c in _circuitos)
                    cboCircuito.Items.Add(c.Nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar circuitos: " + ex.Message);
            }

            dtpFecha.Value = DateTime.Today;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboCircuito.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona un circuito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var circuitoSeleccionado = _circuitos[cboCircuito.SelectedIndex];
            var fecha = dtpFecha.Value;

            var dto = new CrearKartingCarreraDto
            {
                nombreCompeticion = _nombreCompeticion,
                circuitoId = circuitoSeleccionado.Id,
                fecha = fecha
            };

            try
            {
                await _carreraApi.CrearCarreraAsync(dto);
                MessageBox.Show("Carrera creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la carrera: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}