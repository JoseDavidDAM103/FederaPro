using System;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;

namespace FederaProDesktop.Karting
{
    public partial class InicioKartingControl : UserControl
    {
        private TableLayoutPanel tableLayoutPanel1;

        public InicioKartingControl()
        {
            InitializeComponent();
            ConfigurarGraficas();
        }

        private void ConfigurarGraficas()
        {
            tableLayoutPanel1 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                ColumnStyles =
                {
                    new ColumnStyle(SizeType.Percent, 50F),
                    new ColumnStyle(SizeType.Percent, 50F)
                }
            };

            // Gráfico de barras - Pilotos con más puntos
            var chartBarras = new CartesianChart
            {
                Dock = DockStyle.Fill,
                Series = new ISeries[]
                {
                    new ColumnSeries<double>
                    {
                        Values = new double[] { 120, 98, 76, 65 },
                        Name = "Puntos"
                    }
                },
                XAxes = new Axis[]
                {
                    new Axis
                    {
                        Labels = new[] { "Piloto A", "Piloto B", "Piloto C", "Piloto D" },
                        LabelsRotation = 15
                    }
                },
                YAxes = new Axis[]
                {
                    new Axis { Name = "Puntos" }
                }
            };

            // Gráfico de pastel - Reparto de victorias por equipo
            var chartPastel = new PieChart
            {
                Dock = DockStyle.Fill,
                Series = new ISeries[]
                {
                    new PieSeries<double> { Values = new double[] { 45 }, Name = "Equipo 1" },
                    new PieSeries<double> { Values = new double[] { 35 }, Name = "Equipo 2" },
                    new PieSeries<double> { Values = new double[] { 20 }, Name = "Equipo 3" }
                }
            };

            tableLayoutPanel1.Controls.Add(chartBarras, 0, 0);
            tableLayoutPanel1.Controls.Add(chartPastel, 1, 0);

            this.Controls.Add(tableLayoutPanel1);
        }
    }
}
