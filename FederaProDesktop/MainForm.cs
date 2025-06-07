using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FederaProDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CrearBotonesMenu();
            MostrarControl(new InicioControl());
        }

        private void CrearBotonesMenu()
        {
            Dictionary<string, Action> acciones = new Dictionary<string, Action>()
            {
                { "Inicio", () => MostrarControl(new InicioControl()) },
                {
                    "Equipos", () => {
                        var equiposControl = new EquiposControl();
                        equiposControl.VerDetalleEquipo += (equipo) => {
                            MostrarControl(new DetalleEquipoControl(equipo));
                        };
                        MostrarControl(equiposControl);
                    }
                },
                { "Jugadores", () =>
                    {
                        var jugadoresControl = new JugadoresControl();
                        jugadoresControl.VerDetalleJugador += (nombre, posicion) =>
                        {
                            MostrarControl(new DetalleJugadorControl(nombre, posicion));
                        };
                        MostrarControl(jugadoresControl);
                    }
                },
                { "Competiciones", () =>
                    {
                        var competicionesControl = new CompeticionesControl();
                        competicionesControl.VerDetalleCompeticion += (nombre, tipo) =>
                        {
                            MostrarControl(new DetallesCompeticionControl(nombre, tipo));
                        };
                        MostrarControl(competicionesControl);
                    }
                },
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
                    BackColor = Color.FromArgb(60, 60, 90),
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
                BackColor = Color.FromArgb(60, 30, 30),
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
