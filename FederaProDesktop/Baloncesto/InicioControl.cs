using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FederaProDesktop
{
    public partial class InicioControl : UserControl
    {
        public InicioControl()
        {
            InitializeComponent();
            ConfigurarGraficas();
        }

        private void ConfigurarGraficas()
        {
            // Gráfico de barras - Equipos con más victorias
            var barras = new CartesianChart
            {
                Dock = DockStyle.Fill,
                Series = new ISeries[]
                {
                    new ColumnSeries<double>
                    {
                        Values = new double[] { 18, 16, 12, 10 },
                        Name = "Victorias",
                    }
                },
                XAxes = new Axis[]
                {
                    new Axis
                    {
                        Labels = labelsEquipos,
                        LabelsRotation = 15
                    }
                },
                YAxes = new Axis[]
                {
                    new Axis { Name = "Victorias" }
                }
            };

            // Gráfico de pastel - Tipos de competición
            var pastel = new PieChart
            {
                Dock = DockStyle.Fill,
                Series = new ISeries[]
                {
                    new PieSeries<double> { Values = new double[] { 6 }, Name = "Liga" },
                    new PieSeries<double> { Values = new double[] { 2 }, Name = "Copa" },
                    new PieSeries<double> { Values = new double[] { 1 }, Name = "Torneo" }
                }
            };

            // Añadir al layout
            tableLayoutPanel1.Controls.Add(barras, 0, 0);
            tableLayoutPanel1.Controls.Add(pastel, 1, 0);
        }

        private string[] labelsEquipos = { "CB Barcelona", "Real Madrid", "Valencia BC", "Unicaja" };
    }
}