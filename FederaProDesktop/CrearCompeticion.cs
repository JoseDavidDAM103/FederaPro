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
    public partial class CrearCompeticion : UserControl
    {
        public event Action<object> CompeticionCreada;
        private readonly BasketCompeticionApi _apiService = new BasketCompeticionApi();
        private readonly EquipoApiService equipoApiService = new EquipoApiService();
        private List<BasketEquipoDTO> _equiposDisponibles = new();

        public CrearCompeticion()
        {
            InitializeComponent();
            CargarEquiposAsync();
        }

        private async void CargarEquiposAsync()
        {
            try
            {
                _equiposDisponibles = await equipoApiService.GetEquiposAsync();
                lstEquipos.DataSource = _equiposDisponibles;
                lstEquipos.DisplayMember = "Nombre";
                lstEquipos.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar equipos: " + ex.Message);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            var seleccionados = lstEquipos.SelectedItems.Cast<BasketEquipoDTO>();
            var equipoIds = seleccionados.Select(e => e.Id).ToList();
            var nueva = new CrearCompeticionDTO
            {
                Nombre = txtNombre.Text,
                Tipo = txtTipo.Text,
                EquipoIds = equipoIds
            };

            try
            {
                var resultado = await _apiService.CrearCompeticionAsync(nueva);
                CompeticionCreada?.Invoke(resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear competición: " + ex.Message);
            }
        }
    }
}
   
