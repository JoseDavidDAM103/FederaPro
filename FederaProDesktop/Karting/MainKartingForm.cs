using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop.Karting
{
    public partial class MainKartingForm : Form
    {
        public MainKartingForm()
        {
            InitializeComponent();
            CrearBotonesMenu();
            MostrarControl(new InicioKartingControl()); // Control inicial, por implementar
        }

        private void CrearBotonesMenu()
        {
            Dictionary<string, Action> acciones = new Dictionary<string, Action>()
            {
                { "Inicio", () => MostrarControl(new InicioKartingControl()) },

                { "Pilotos", () => {
                    var pilotosControl = new PilotosControl();
                    pilotosControl.VerDetallePiloto += (nombre, categoria) =>
                    {
                        MostrarControl(new DetallePilotoControl(nombre, categoria));
                    };
                    MostrarControl(pilotosControl);
                }},

                { "Equipos", () => {
                    var equiposControl = new EquiposKartingControl();
                    equiposControl.VerDetalleEquipo += (equipo, pais) =>
                    {
                        MostrarControl(new DetalleEquipoKartingControl(equipo, pais));
                    };
                    MostrarControl(equiposControl);
                }},

                { "Circuitos", () => {
                    MostrarControl(new CircuitosControl());
                }},

                { "Competiciones", () => {
                    var competicionesControl = new CompeticionesKartingControl();
                    competicionesControl.VerDetalleCompeticionKarting += (nombre, tipo) =>
                    {
                        MostrarControl(new DetalleCompeticionKarting(nombre, tipo));
                    };
                    MostrarControl(competicionesControl);
                }}
            };

            foreach (var item in acciones)
            {
                Button btn = new Button
                {
                    Text = item.Key,
                    Dock = DockStyle.Top,
                    Height = 45,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(80, 30, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(10, 0, 0, 0)
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += (s, e) => item.Value.Invoke();
                panelMenuTop.Controls.Add(btn);
                panelMenuTop.Controls.SetChildIndex(btn, 0);
            }

            Button btnCerrarSesion = new Button
            {
                Text = "Cerrar sesión",
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(100, 40, 40),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.Click += (s, e) => Application.Exit();
            panelMenuBottom.Controls.Add(btnCerrarSesion);
        }

        private void MostrarControl(UserControl control)
        {
            panelContenido.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }
    }
}
