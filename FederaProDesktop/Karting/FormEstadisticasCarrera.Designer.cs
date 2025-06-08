namespace FederaProDesktop.Karting
{
    partial class FormEstadisticasCarrera
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvEstadisticas;
        private System.Windows.Forms.Button btnGuardar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvEstadisticas = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();

            this.colIdPiloto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombrePiloto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTiempoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVueltas = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadisticas)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Size = new System.Drawing.Size(500, 25);

            // dgvEstadisticas
            this.dgvEstadisticas.AllowUserToAddRows = false;
            this.dgvEstadisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadisticas.Location = new System.Drawing.Point(20, 60);
            this.dgvEstadisticas.Size = new System.Drawing.Size(650, 300);
            this.dgvEstadisticas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colIdPiloto,
                this.colNombrePiloto,
                this.colPosicion,
                this.colTiempoTotal,
                this.colVueltas
            });

            // btnGuardar
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(20, 380);
            this.btnGuardar.Size = new System.Drawing.Size(120, 35);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // Columnas
            this.colIdPiloto.HeaderText = "ID";
            this.colIdPiloto.Name = "colIdPiloto";
            this.colIdPiloto.ReadOnly = true;

            this.colNombrePiloto.HeaderText = "Piloto";
            this.colNombrePiloto.Name = "colNombrePiloto";
            this.colNombrePiloto.ReadOnly = true;

            this.colPosicion.HeaderText = "Posición";
            this.colPosicion.Name = "colPosicion";

            this.colTiempoTotal.HeaderText = "Tiempo Total";
            this.colTiempoTotal.Name = "colTiempoTotal";

            this.colVueltas.HeaderText = "Vueltas";
            this.colVueltas.Name = "colVueltas";

            // FormEstadisticasCarrera
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvEstadisticas);
            this.Controls.Add(this.btnGuardar);
            this.Name = "FormEstadisticasCarrera";
            this.Text = "Estadísticas de Carrera";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadisticas)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPiloto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombrePiloto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTiempoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVueltas;
    }
}