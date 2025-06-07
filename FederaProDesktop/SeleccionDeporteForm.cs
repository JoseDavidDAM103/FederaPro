using System;
using System.Drawing;
using System.Windows.Forms;

namespace FederaProDesktop
{
    public partial class SeleccionDeporteForm : Form
    {
        public SeleccionDeporteForm()
        {
            InitializeComponent();
            InicializarPanelDeportes();
        }

        private void InicializarPanelDeportes()
        {
            string[] deportesHabilitados = new[] {
                "Baloncesto", "Karting"
            };

            string[] todosLosDeportes = new[] {
                "Baloncesto", "Fútbol", "Tenis", "Padel", "Karting", "Karate", "Natación", "Voleibol", "Ciclismo"
            };

            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20),
                WrapContents = true
            };

            foreach (string deporte in todosLosDeportes)
            {
                bool habilitado = Array.Exists(deportesHabilitados, d => d == deporte);
                Button btn = new Button
                {
                    Text = deporte,
                    Tag = deporte,
                    Width = 200,
                    Height = 100,
                    Margin = new Padding(15),
                    BackColor = habilitado ? Color.FromArgb(60, 90, 130) : Color.Gray,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Enabled = habilitado
                };
                btn.FlatAppearance.BorderSize = 0;
                if (habilitado)
                {
                    btn.Click += btnDeporte_Click;
                }
                panel.Controls.Add(btn);
            }

            this.Controls.Add(panel);
        }

        private void btnDeporte_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string deporteSeleccionado = btn.Tag.ToString();

            MessageBox.Show($"Has seleccionado el deporte: {deporteSeleccionado}", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Aquí podrías almacenar la selección y redirigir al siguiente formulario
            this.Close();
        }
    }
}

