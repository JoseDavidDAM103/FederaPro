namespace FederaProDesktop
{
    partial class DetalleEquipoControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Button btnJugadores;
        private Button btnEstadisticas;
        private Button btnPartidos;
        private Panel panelBotones;
        private Panel panelContenido;

        private Panel panelJugadores;
        private Button btnImportarJugadoresCsv;
        private DataGridView dgvJugadores;


        private Panel panelPartidos;
        private DataGridView dgvPartidos;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.btnJugadores = new Button();
            this.btnEstadisticas = new Button();
            this.btnPartidos = new Button();
            this.panelBotones = new Panel();
            this.panelContenido = new Panel();
            this.panelJugadores = new Panel();
            this.btnImportarJugadoresCsv = new Button();
            this.dgvJugadores = new DataGridView();

            this.panelBotones.SuspendLayout();
            this.panelJugadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Dock = DockStyle.Top;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.Padding = new Padding(10);
            this.lblTitulo.Text = "Nombre del equipo";
            this.lblTitulo.Height = 50;

            // panelBotones
            this.panelBotones.Dock = DockStyle.Top;
            this.panelBotones.Height = 40;
            this.panelBotones.BackColor = Color.LightGray;
            this.panelBotones.Controls.Add(this.btnJugadores);
            this.panelBotones.Controls.Add(this.btnEstadisticas);
            this.panelBotones.Controls.Add(this.btnPartidos);

            // btnJugadores
            this.btnJugadores.Text = "Jugadores";
            this.btnJugadores.Width = 100;
            this.btnJugadores.Location = new Point(10, 7);
            this.btnJugadores.Click += new System.EventHandler(this.btnJugadores_Click);

            // btnEstadisticas
            this.btnEstadisticas.Text = "Estadísticas";
            this.btnEstadisticas.Width = 100;
            this.btnEstadisticas.Location = new Point(120, 7);
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);

            // btnPartidos
            this.btnPartidos.Text = "Partidos";
            this.btnPartidos.Width = 100;
            this.btnPartidos.Location = new Point(230, 7);
            this.btnPartidos.Click += new System.EventHandler(this.btnPartidos_Click);

            this.panelPartidos = new Panel();
            this.panelPartidos.Dock = DockStyle.Fill;
            this.panelPartidos.Visible = false;

            this.dgvPartidos = new DataGridView();
            this.dgvPartidos.Dock = DockStyle.Fill;
            this.dgvPartidos.ReadOnly = true;
            this.dgvPartidos.AllowUserToAddRows = false;
            this.dgvPartidos.AllowUserToDeleteRows = false;
            this.dgvPartidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartidos.RowHeadersVisible = false;
            this.dgvPartidos.BorderStyle = BorderStyle.None;
            this.dgvPartidos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            this.dgvPartidos.BackgroundColor = Color.White; this.dgvJugadores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 90, 130);
            this.dgvPartidos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvPartidos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvPartidos.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvPartidos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 140, 180);
            this.dgvPartidos.DefaultCellStyle.SelectionForeColor = Color.White;

            this.panelPartidos.Controls.Add(this.dgvPartidos);
            this.panelContenido.Controls.Add(this.panelPartidos);

            // panelContenido
            this.panelContenido.Dock = DockStyle.Fill;
            this.panelContenido.BackColor = Color.WhiteSmoke;

            // panelJugadores
            this.panelJugadores.Dock = DockStyle.Fill;
            this.panelJugadores.Visible = false;

            // btnImportarJugadoresCsv
            this.btnImportarJugadoresCsv.Text = "Importar CSV";
            this.btnImportarJugadoresCsv.Size = new Size(120, 25);
            this.btnImportarJugadoresCsv.Dock = DockStyle.Top;
            this.btnImportarJugadoresCsv.Margin = new Padding(10);
            this.btnImportarJugadoresCsv.Click += new System.EventHandler(this.btnImportarJugadoresCsv_Click);

            // dgvJugadores
            this.dgvJugadores.Dock = DockStyle.Fill;
            this.dgvJugadores.ReadOnly = true;
            this.dgvJugadores.AllowUserToAddRows = false;
            this.dgvJugadores.AllowUserToDeleteRows = false;
            this.dgvJugadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvJugadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJugadores.RowHeadersVisible = false;
            this.dgvJugadores.BorderStyle = BorderStyle.None;
            this.dgvJugadores.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            this.dgvJugadores.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 90, 130);
            this.dgvJugadores.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvJugadores.GridColor = Color.LightGray;
            this.dgvJugadores.BackgroundColor = Color.White; this.dgvJugadores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 90, 130);
            this.dgvJugadores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvJugadores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvJugadores.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvJugadores.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 140, 180);
            this.dgvJugadores.DefaultCellStyle.SelectionForeColor = Color.White;

            this.panelJugadores.Controls.Add(this.dgvJugadores);
            this.panelJugadores.Controls.Add(this.btnImportarJugadoresCsv);

            // DetalleEquipoControl
            this.Controls.Add(this.panelJugadores);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.lblTitulo);
            this.Name = "DetalleEquipoControl";
            this.Size = new Size(800, 500);

            this.panelBotones.ResumeLayout(false);
            this.panelJugadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).EndInit();
            this.ResumeLayout(false);

            Font buttonFont = new Font("Segoe UI", 9F, FontStyle.Bold);
            Color mainColor = Color.SteelBlue;
            Color hoverColor = Color.FromArgb(70, 110, 160);

            // btnJugadores
            this.btnJugadores.Text = "Jugadores";
            this.btnJugadores.Font = buttonFont;
            this.btnJugadores.ForeColor = Color.White;
            this.btnJugadores.BackColor = mainColor;
            this.btnJugadores.FlatStyle = FlatStyle.Flat;
            this.btnJugadores.FlatAppearance.BorderSize = 0;
            this.btnJugadores.Size = new Size(100, 30);
            this.btnJugadores.Location = new Point(10, 5);

            // btnEstadisticas
            this.btnEstadisticas.Text = "Estadísticas";
            this.btnEstadisticas.Font = buttonFont;
            this.btnEstadisticas.ForeColor = Color.White;
            this.btnEstadisticas.BackColor = mainColor;
            this.btnEstadisticas.FlatStyle = FlatStyle.Flat;
            this.btnEstadisticas.FlatAppearance.BorderSize = 0;
            this.btnEstadisticas.Size = new Size(100, 30);
            this.btnEstadisticas.Location = new Point(120, 5);

            // btnPartidos
            this.btnPartidos.Text = "Partidos";
            this.btnPartidos.Font = buttonFont;
            this.btnPartidos.ForeColor = Color.White;
            this.btnPartidos.BackColor = mainColor;
            this.btnPartidos.FlatStyle = FlatStyle.Flat;
            this.btnPartidos.FlatAppearance.BorderSize = 0;
            this.btnPartidos.Size = new Size(100, 30);
            this.btnPartidos.Location = new Point(230, 5);

            // btnImportarJugadoresCsv
            this.btnImportarJugadoresCsv.Text = "Importar CSV";
            this.btnImportarJugadoresCsv.Font = buttonFont;
            this.btnImportarJugadoresCsv.ForeColor = Color.White;
            this.btnImportarJugadoresCsv.BackColor = Color.MediumSeaGreen;
            this.btnImportarJugadoresCsv.FlatStyle = FlatStyle.Flat;
            this.btnImportarJugadoresCsv.FlatAppearance.BorderSize = 0;
            this.btnImportarJugadoresCsv.Size = new Size(130, 32);
            this.btnImportarJugadoresCsv.Location = new Point(10, 10);
            this.btnImportarJugadoresCsv.Margin = new Padding(10);
        }
    }
}
