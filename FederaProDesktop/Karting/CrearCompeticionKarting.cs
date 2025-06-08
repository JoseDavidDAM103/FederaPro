using FederaProDesktop.Karting.DTOs;
using FederaProDesktop.Karting.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FederaProDesktop.Karting
{
    public partial class CrearCompeticionKarting : UserControl
    {
        private readonly KartingCompeticionApiService _apiService = new();
        private readonly EquipoApiService _apiEquipoService = new();
        private List<KartingEquipo> equipos = new();

        public event Action<KartingCompeticion> CompeticionCreada;

        public CrearCompeticionKarting()
        {
            InitializeComponent();
            _ = CargarEquiposAsync();
        }

        private async Task CargarEquiposAsync()
        {
            equipos = await _apiEquipoService.ObtenerEquiposAsync();
            checkedListBoxEquipos.Items.Clear();

            foreach (var equipo in equipos)
            {
                checkedListBoxEquipos.Items.Add(equipo.Nombre);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var nombre = txtNombre.Text.Trim();
            var tipo = txtTipo.Text.Trim();
            var categoria = txtCategoria.Text.Trim();
            var fechaInicio = dtpFechaInicio.Value;
            var fechaFin = dtpFechaFin.Value;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(tipo) || string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Nombre, tipo y categoría son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var seleccionados = checkedListBoxEquipos.CheckedItems.Cast<string>().ToList();
            var equiposSeleccionados = equipos.Where(e => seleccionados.Contains(e.Nombre)).ToList();

            var dto = new CrearKartingCompeticionDto
            {
                nombre = nombre,
                tipo = tipo,
                categoria = categoria,
                fechaInicio = fechaInicio,
                fechaFin = fechaFin,
                equiposIds = equiposSeleccionados.Select(e => (long)e.Id).ToList()
            };

            try
            {
                await _apiService.CrearCompeticionAsync(dto);
                MessageBox.Show("Competición creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aquí puedes llamar a CompeticionCreada con datos reales si necesitas refrescar listas, etc.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear competición: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}