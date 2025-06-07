namespace FederaProDesktop
{
    partial class FormEstadisticasPartido
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private GroupBox groupEquipoLocal;
        private GroupBox groupEquipoVisitante;
        private Label lblPuntosLocal;
        private Label lblRebotesLocal;
        private Label lblAsistenciasLocal;
        private Label lblRobosLocal;
        private Label lblTaponesLocal;
        private Label lblPerdidasLocal;

        private Label lblPuntosVisitante;
        private Label lblRebotesVisitante;
        private Label lblAsistenciasVisitante;
        private Label lblRobosVisitante;
        private Label lblTaponesVisitante;
        private Label lblPerdidasVisitante;

        private NumericUpDown numPuntosLocal, numRebotesLocal, numAsistenciasLocal, numRobosLocal, numTaponesLocal, numPerdidasLocal;
        private NumericUpDown numPuntosVisitante, numRebotesVisitante, numAsistenciasVisitante, numRobosVisitante, numTaponesVisitante, numPerdidasVisitante;

        private DataGridView dgvEstadisticasJugadores;
        private Button btnGuardar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            groupEquipoLocal = new GroupBox();
            groupEquipoVisitante = new GroupBox();
            dgvEstadisticasJugadores = new DataGridView();
            btnGuardar = new Button();

            lblPuntosLocal = new Label();
            lblRebotesLocal = new Label();
            lblAsistenciasLocal = new Label();
            lblRobosLocal = new Label();
            lblTaponesLocal = new Label();
            lblPerdidasLocal = new Label();

            lblPuntosVisitante = new Label();
            lblRebotesVisitante = new Label();
            lblAsistenciasVisitante = new Label();
            lblRobosVisitante = new Label();
            lblTaponesVisitante = new Label();
            lblPerdidasVisitante = new Label();

            numPuntosLocal = new NumericUpDown();
            numRebotesLocal = new NumericUpDown();
            numAsistenciasLocal = new NumericUpDown();
            numRobosLocal = new NumericUpDown();
            numTaponesLocal = new NumericUpDown();
            numPerdidasLocal = new NumericUpDown();

            numPuntosVisitante = new NumericUpDown();
            numRebotesVisitante = new NumericUpDown();
            numAsistenciasVisitante = new NumericUpDown();
            numRobosVisitante = new NumericUpDown();
            numTaponesVisitante = new NumericUpDown();
            numPerdidasVisitante = new NumericUpDown();

            // lblTitulo
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Text = "Registro de Estadísticas del Partido";
            lblTitulo.Height = 40;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // groupEquipoLocal
            groupEquipoLocal.Text = "Equipo Local";
            groupEquipoLocal.Location = new Point(20, 50);
            groupEquipoLocal.Size = new Size(350, 230);

            // groupEquipoVisitante
            groupEquipoVisitante.Text = "Equipo Visitante";
            groupEquipoVisitante.Location = new Point(390, 50);
            groupEquipoVisitante.Size = new Size(350, 230);

            // Etiquetas y NumericUpDown - Local
            CrearCampoEstadistica(lblPuntosLocal, numPuntosLocal, "Puntos:", 20);
            CrearCampoEstadistica(lblRebotesLocal, numRebotesLocal, "Rebotes:", 55);
            CrearCampoEstadistica(lblAsistenciasLocal, numAsistenciasLocal, "Asistencias:", 90);
            CrearCampoEstadistica(lblRobosLocal, numRobosLocal, "Robos:", 125);
            CrearCampoEstadistica(lblTaponesLocal, numTaponesLocal, "Tapones:", 160);
            CrearCampoEstadistica(lblPerdidasLocal, numPerdidasLocal, "Pérdidas:", 195);

            // Etiquetas y NumericUpDown - Visitante
            CrearCampoEstadistica(lblPuntosVisitante, numPuntosVisitante, "Puntos:", 20);
            CrearCampoEstadistica(lblRebotesVisitante, numRebotesVisitante, "Rebotes:", 55);
            CrearCampoEstadistica(lblAsistenciasVisitante, numAsistenciasVisitante, "Asistencias:", 90);
            CrearCampoEstadistica(lblRobosVisitante, numRobosVisitante, "Robos:", 125);
            CrearCampoEstadistica(lblTaponesVisitante, numTaponesVisitante, "Tapones:", 160);
            CrearCampoEstadistica(lblPerdidasVisitante, numPerdidasVisitante, "Pérdidas:", 195);

            // Añadir controles a los GroupBox
            groupEquipoLocal.Controls.AddRange(new Control[] {
                lblPuntosLocal, numPuntosLocal,
                lblRebotesLocal, numRebotesLocal,
                lblAsistenciasLocal, numAsistenciasLocal,
                lblRobosLocal, numRobosLocal,
                lblTaponesLocal, numTaponesLocal,
                lblPerdidasLocal, numPerdidasLocal
            });

            groupEquipoVisitante.Controls.AddRange(new Control[] {
                lblPuntosVisitante, numPuntosVisitante,
                lblRebotesVisitante, numRebotesVisitante,
                lblAsistenciasVisitante, numAsistenciasVisitante,
                lblRobosVisitante, numRobosVisitante,
                lblTaponesVisitante, numTaponesVisitante,
                lblPerdidasVisitante, numPerdidasVisitante
            });

            // dgvEstadisticasJugadores
            dgvEstadisticasJugadores.Location = new Point(20, 300);
            dgvEstadisticasJugadores.Size = new Size(720, 260);
            dgvEstadisticasJugadores.ReadOnly = false;
            dgvEstadisticasJugadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEstadisticasJugadores.AllowUserToAddRows = false;
            dgvEstadisticasJugadores.AllowUserToDeleteRows = false;
            dgvEstadisticasJugadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // btnGuardar
            btnGuardar.Text = "Guardar Estadísticas";
            btnGuardar.Location = new Point(305, 575);
            btnGuardar.Size = new Size(150, 35);
            btnGuardar.Click += btnGuardar_Click;

            // Añadir todo al formulario
            Controls.Add(lblTitulo);
            Controls.Add(groupEquipoLocal);
            Controls.Add(groupEquipoVisitante);
            Controls.Add(dgvEstadisticasJugadores);
            Controls.Add(btnGuardar);

            Name = "FormEstadisticasPartido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Estadísticas del Partido";
            ClientSize = new Size(760, 630);
        }

        private void CrearCampoEstadistica(Label lbl, NumericUpDown num, string texto, int y)
        {
            lbl.Text = texto;
            lbl.Location = new Point(10, y);
            lbl.Size = new Size(100, 23);

            num.Location = new Point(120, y);
            num.Size = new Size(120, 27);
            num.Maximum = 300;
        }
    }
}