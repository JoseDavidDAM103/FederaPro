namespace FederaProDesktop
{
    partial class DetalleCompeticion
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Button btnClasificacion;
        private Button btnPartidos;
        private Panel panelBotones;
        private Panel panelContenido;
        private Panel panelClasificacion;
        private Panel panelPartidos;
        private DataGridView dgvClasificacion;
        private DataGridView dgvPartidos;
        private ComboBox cboJornada;
        private Button btnGenerarPartidos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.btnClasificacion = new Button();
            this.btnPartidos = new Button();
            this.panelBotones = new Panel();
            this.panelContenido = new Panel();
            this.panelClasificacion = new Panel();
            this.panelPartidos = new Panel();
            this.dgvClasificacion = new DataGridView();
            this.dgvPartidos = new DataGridView();
            this.cboJornada = new ComboBox();
            this.btnGenerarPartidos = new Button();

            // lblTitulo
            this.lblTitulo.Dock = DockStyle.Top;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.Padding = new Padding(10);
            this.lblTitulo.Height = 50;

            // panelBotones
            this.panelBotones.Dock = DockStyle.Top;
            this.panelBotones.Height = 40;
            this.panelBotones.BackColor = Color.LightGray;
            this.panelBotones.Controls.Add(this.btnClasificacion);
            this.panelBotones.Controls.Add(this.btnPartidos);

            // btnClasificacion
            this.btnClasificacion.Text = "Clasificación";
            this.btnClasificacion.Width = 120;
            this.btnClasificacion.Location = new Point(10, 7);
            this.btnClasificacion.Click += new EventHandler(this.btnClasificacion_Click);

            // btnPartidos
            this.btnPartidos.Text = "Partidos";
            this.btnPartidos.Width = 120;
            this.btnPartidos.Location = new Point(140, 7);
            this.btnPartidos.Click += new EventHandler(this.btnPartidos_Click);

            // panelContenido
            this.panelContenido.Dock = DockStyle.Fill;
            this.panelContenido.BackColor = Color.WhiteSmoke;

            // panelClasificacion
            this.panelClasificacion.Dock = DockStyle.Fill;
            this.panelClasificacion.Visible = false;
            this.panelClasificacion.Controls.Add(this.dgvClasificacion);

            // dgvClasificacion
            this.dgvClasificacion.Dock = DockStyle.Fill;
            this.dgvClasificacion.ReadOnly = true;
            this.dgvClasificacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClasificacion.ReadOnly = true;
            this.dgvClasificacion.AllowUserToAddRows = false;
            this.dgvClasificacion.AllowUserToDeleteRows = false;
            this.dgvClasificacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.btnGenerarPartidos.Text = "Generar partidos automáticamente";
            this.btnGenerarPartidos.Dock = DockStyle.Top;
            this.btnGenerarPartidos.Height = 30;
            this.btnGenerarPartidos.Click += new EventHandler(this.btnGenerarPartidos_Click);

            // panelPartidos
            this.panelPartidos.Dock = DockStyle.Fill;
            this.panelPartidos.Visible = false;
            this.panelPartidos.Controls.Add(this.dgvPartidos);
            this.panelPartidos.Controls.Add(this.cboJornada);
            this.panelPartidos.Controls.Add(this.btnGenerarPartidos);


            // cboJornada
            this.cboJornada.Dock = DockStyle.Top;
            this.cboJornada.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboJornada.Items.Add("Todos los partidos");
            this.cboJornada.SelectedIndex = 0;
            this.cboJornada.SelectedIndexChanged += new EventHandler(this.cboJornada_SelectedIndexChanged);

            // dgvPartidos
            this.dgvPartidos.Dock = DockStyle.Fill;
            this.dgvPartidos.ReadOnly = true;
            this.dgvPartidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartidos.ReadOnly = true;
            this.dgvPartidos.AllowUserToAddRows = false;
            this.dgvPartidos.AllowUserToDeleteRows = false;
            this.dgvPartidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartidos.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvPartidos_CellDoubleClick);

            // DetalleCompeticionControl
            this.Controls.Add(this.panelPartidos);
            this.Controls.Add(this.panelClasificacion);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.lblTitulo);
            this.Name = "DetalleCompeticionControl";
            this.Size = new Size(800, 500);
        }

    }
}
