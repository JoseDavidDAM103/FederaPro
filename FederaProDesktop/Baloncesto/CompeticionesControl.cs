using FederaProDesktop.Servicios.Api;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop
{
    public partial class CompeticionesControl : UserControl
    {
        public event Action<string, string> VerDetalleCompeticion;
        private readonly BasketCompeticionApi _apiService = new BasketCompeticionApi();
        private FlowLayoutPanel panelCompeticiones;

        public CompeticionesControl()
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
                var lista = await _apiService.GetCompeticionesAsync();
                panelCompeticiones.Controls.Clear();

                foreach (var competicion in lista)
                {
                    var btn = new Button
                    {
                        Width = 220,
                        Height = 100,
                        Margin = new Padding(10),
                        BackColor = Color.FromArgb(70, 130, 180),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        Text = $"{competicion.Nombre}\nTipo: {competicion.Tipo}",
                        Tag = competicion
                    };
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += (s, e) => AbrirDetalleCompeticion(competicion.Nombre, competicion.Tipo);
                    panelCompeticiones.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar competiciones: {ex.Message}");
            }
        }

        private void AbrirDetalleCompeticion(string nombre, string tipo)
        {
            var detalle = new DetalleCompeticion(nombre, tipo)
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
            var crearControl = new CrearCompeticion
            {
                Dock = DockStyle.Fill
            };

            var form = new Form
            {
                Text = "Crear nueva competición",
                Size = new Size(600, 500),
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
