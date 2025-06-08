namespace FederaProDesktop.Karting
{
    partial class DetalleCompeticionKarting
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnClasificacion;
        private System.Windows.Forms.Button btnCarreras;
        private System.Windows.Forms.Panel panelContenido;

        private System.Windows.Forms.Panel panelClasificacion;
        private System.Windows.Forms.Label lblPilotos;
        private System.Windows.Forms.DataGridView dgvClasificacionPilotos;
        private System.Windows.Forms.Label lblEquipos;
        private System.Windows.Forms.DataGridView dgvClasificacionEquipos;

        private System.Windows.Forms.Panel panelCarreras;
        private System.Windows.Forms.ComboBox cboCarrera;
        private System.Windows.Forms.DataGridView dgvCarreras;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnClasificacion = new System.Windows.Forms.Button();
            this.btnCarreras = new System.Windows.Forms.Button();
            this.panelContenido = new System.Windows.Forms.Panel();

            this.panelClasificacion = new System.Windows.Forms.Panel();
            this.lblPilotos = new System.Windows.Forms.Label();
            this.dgvClasificacionPilotos = new System.Windows.Forms.DataGridView();
            this.lblEquipos = new System.Windows.Forms.Label();
            this.dgvClasificacionEquipos = new System.Windows.Forms.DataGridView();

            this.panelCarreras = new System.Windows.Forms.Panel();
            this.cboCarrera = new System.Windows.Forms.ComboBox();
            this.dgvCarreras = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvClasificacionPilotos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasificacionEquipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarreras)).BeginInit();
            this.panelClasificacion.SuspendLayout();
            this.panelCarreras.SuspendLayout();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Size = new System.Drawing.Size(600, 30);
            this.lblTitulo.Text = "Título Competición";

            // btnClasificacion
            this.btnClasificacion.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClasificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClasificacion.FlatAppearance.BorderSize = 0;
            this.btnClasificacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClasificacion.ForeColor = System.Drawing.Color.White;
            this.btnClasificacion.Location = new System.Drawing.Point(650, 10);
            this.btnClasificacion.Size = new System.Drawing.Size(120, 30);
            this.btnClasificacion.Text = "Clasificación";
            this.btnClasificacion.UseVisualStyleBackColor = false;
            this.btnClasificacion.Click += new System.EventHandler(this.btnClasificacion_Click);

            // btnCarreras
            this.btnCarreras.BackColor = System.Drawing.Color.Teal;
            this.btnCarreras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarreras.FlatAppearance.BorderSize = 0;
            this.btnCarreras.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCarreras.ForeColor = System.Drawing.Color.White;
            this.btnCarreras.Location = new System.Drawing.Point(780, 10);
            this.btnCarreras.Size = new System.Drawing.Size(120, 30);
            this.btnCarreras.Text = "Carreras";
            this.btnCarreras.UseVisualStyleBackColor = false;
            this.btnCarreras.Click += new System.EventHandler(this.btnCarreras_Click);

            // panelContenido
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelContenido.Location = new System.Drawing.Point(0, 50);
            this.panelContenido.Size = new System.Drawing.Size(920, 450);

            // panelClasificacion
            this.panelClasificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClasificacion.Visible = false;

            // lblPilotos
            this.lblPilotos.Text = "Clasificación de Pilotos";
            this.lblPilotos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPilotos.Location = new System.Drawing.Point(20, 10);
            this.lblPilotos.AutoSize = true;

            // dgvClasificacionPilotos
            this.dgvClasificacionPilotos.Location = new System.Drawing.Point(20, 35);
            this.dgvClasificacionPilotos.Size = new System.Drawing.Size(880, 180);
            this.dgvClasificacionPilotos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClasificacionPilotos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasificacionPilotos.ReadOnly = true;

            // lblEquipos
            this.lblEquipos.Text = "Clasificación de Equipos";
            this.lblEquipos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEquipos.Location = new System.Drawing.Point(20, 225);
            this.lblEquipos.AutoSize = true;

            // dgvClasificacionEquipos
            this.dgvClasificacionEquipos.Location = new System.Drawing.Point(20, 250);
            this.dgvClasificacionEquipos.Size = new System.Drawing.Size(880, 180);
            this.dgvClasificacionEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClasificacionEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasificacionEquipos.ReadOnly = true;

            // panelCarreras
            this.panelCarreras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCarreras.Visible = false;

            // cboCarrera
            this.cboCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCarrera.Location = new System.Drawing.Point(20, 15);
            this.cboCarrera.Size = new System.Drawing.Size(200, 24);
            this.cboCarrera.SelectedIndexChanged += new System.EventHandler(this.cboCarrera_SelectedIndexChanged);

            // dgvCarreras
            this.dgvCarreras.Location = new System.Drawing.Point(0, 50);
            this.dgvCarreras.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCarreras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarreras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarreras.ReadOnly = true;
            this.dgvCarreras.Height = 400;
            this.dgvCarreras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarreras_CellDoubleClick);

            // Add to panels
            this.panelClasificacion.Controls.Add(this.lblPilotos);
            this.panelClasificacion.Controls.Add(this.dgvClasificacionPilotos);
            this.panelClasificacion.Controls.Add(this.lblEquipos);
            this.panelClasificacion.Controls.Add(this.dgvClasificacionEquipos);
            this.panelCarreras.Controls.Add(this.cboCarrera);
            this.panelCarreras.Controls.Add(this.dgvCarreras);

            // DetalleCompeticionKarting
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnClasificacion);
            this.Controls.Add(this.btnCarreras);
            this.panelContenido.Controls.Add(this.panelClasificacion);
            this.panelContenido.Controls.Add(this.panelCarreras);
            this.Name = "DetalleCompeticionKarting";
            this.Size = new System.Drawing.Size(920, 500);

            this.panelClasificacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasificacionPilotos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasificacionEquipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarreras)).EndInit();
            this.panelCarreras.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}