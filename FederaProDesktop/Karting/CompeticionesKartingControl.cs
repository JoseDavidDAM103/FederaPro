using FederaProDesktop.Karting.Servicios;
using FederaProDesktop.Karting.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop.Karting
{
    public partial class CompeticionesKartingControl : UserControl
    {
        public event Action<string, string> VerDetalleCompeticionKarting;
        private readonly KartingCompeticionApiService _apiService = new();
        private FlowLayoutPanel panelCompeticiones;

        public CompeticionesKartingControl()
        {
            InitializeComponent();
            InicializarPanelCompeticiones();
            _ = CargarCompeticionesAsync();
        }

        private void InicializarPanelCompeticiones()
        {
            panelCompeticiones = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20),
                WrapContents = true
            };
            Controls.Add(panelCompeticiones);
            Controls.SetChildIndex(panelCompeticiones, 0);
        }

        private async Task CargarCompeticionesAsync()
        {
            try
            {
                var lista = await _apiService.ObtenerCompeticionesAsync();
                panelCompeticiones.Controls.Clear();

                foreach (var competicion in lista)
                {
                    var btn = new Button
                    {
                        Width = 220,
                        Height = 100,
                        Margin = new Padding(10),
                        BackColor = Color.FromArgb(220, 80, 50), // Color adaptado a karting
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        Text = $"{competicion.Nombre}\nCategoría: {competicion.Categoria}",
                        Tag = competicion
                    };
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += (s, e) => AbrirDetalle(competicion.Nombre, competicion.Categoria);
                    panelCompeticiones.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar competiciones: {ex.Message}");
            }
        }

        private void AbrirDetalle(string nombre, string categoria)
        {
            var detalle = new DetalleCompeticionKarting(nombre, categoria)
            {
                Dock = DockStyle.Fill
            };

            var form = new Form
            {
                Text = $"Detalle de la competición: {nombre}",
                Size = new Size(850, 600),
                StartPosition = FormStartPosition.CenterParent
            };

            form.Controls.Add(detalle);
            form.ShowDialog();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            var crearControl = new CrearCompeticionKarting
            {
                Dock = DockStyle.Fill
            };

            var form = new Form
            {
                Text = "Crear nueva competición (Karting)",
                Size = new Size(500, 500),
                StartPosition = FormStartPosition.CenterParent
            };

            form.Controls.Add(crearControl);

            crearControl.CompeticionCreada += async (nueva) =>
            {
                form.Close();
                MessageBox.Show("Competición creada con éxito.");
                await CargarCompeticionesAsync();
            };

            form.ShowDialog();
        }
    }
}