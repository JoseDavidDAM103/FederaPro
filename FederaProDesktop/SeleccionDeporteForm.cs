using FederaProDesktop.DTOs;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop
{
    public partial class SeleccionDeporteForm : Form
    {
        private UsuarioRegistroRequest usuario;
        private Panel panelLoading;
        private Label lblCargando;

        public SeleccionDeporteForm(UsuarioRegistroRequest usuarioBase)
        {
            InitializeComponent();
            usuario = usuarioBase;
            InicializarPanelDeportes();
            InicializarPanelCarga();
        }

        private void InicializarPanelDeportes()
        {
            string[] deportesHabilitados = { "Baloncesto", "Karting" };
            string[] todosLosDeportes = { "Baloncesto", "Fútbol", "Tenis", "Padel", "Karting", "Karate", "Natación", "Voleibol", "Ciclismo" };

            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20),
                WrapContents = true
            };

            foreach (string deporte in todosLosDeportes)
            {
                bool habilitado = deportesHabilitados.Contains(deporte);
                Color colorTarjeta = deporte == "Karting" ? Color.FromArgb(40, 100, 70) : Color.FromArgb(60, 90, 130);

                Button btn = new Button
                {
                    Text = deporte,
                    Tag = deporte,
                    Width = 200,
                    Height = 100,
                    Margin = new Padding(15),
                    BackColor = habilitado ? colorTarjeta : Color.Gray,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Enabled = habilitado
                };
                btn.FlatAppearance.BorderSize = 0;

                if (habilitado)
                    btn.Click += btnDeporte_Click;

                panel.Controls.Add(btn);
            }

            this.Controls.Add(panel);
        }

        private void InicializarPanelCarga()
        {
            panelLoading = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(180, 0, 0, 0),
                Visible = false
            };

            lblCargando = new Label
            {
                Text = "Procesando...",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = true
            };

            panelLoading.Controls.Add(lblCargando);
            this.Controls.Add(panelLoading);
            panelLoading.BringToFront();

            panelLoading.Resize += (s, e) =>
            {
                lblCargando.Location = new Point(
                    (panelLoading.Width - lblCargando.Width) / 2,
                    (panelLoading.Height - lblCargando.Height) / 2
                );
            };
        }

        private async void btnDeporte_Click(object sender, EventArgs e)
        {
            panelLoading.Visible = true;
            panelLoading.BringToFront();

            try
            {
                Button btn = sender as Button;
                string deporteSeleccionado = btn.Tag.ToString();

                var api = new UsuarioApiService();
                var deportes = await api.ObtenerDeportesAsync();
                var deporteSeleccionadoObj = deportes.FirstOrDefault(d => d.Nombre.Equals(deporteSeleccionado, StringComparison.OrdinalIgnoreCase));

                if (deporteSeleccionadoObj == null)
                {
                    MessageBox.Show("No se pudo encontrar el deporte seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                usuario.IdDeporte = deporteSeleccionadoObj.Id;

                bool registrado = await api.RegistrarUsuarioAsync(usuario);
                if (!registrado)
                {
                    MessageBox.Show("No se pudo registrar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            finally
            {
                panelLoading.Visible = false;
            }
        }
    }
}

