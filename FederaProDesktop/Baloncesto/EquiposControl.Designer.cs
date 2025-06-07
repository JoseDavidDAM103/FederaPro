namespace FederaProDesktop
{
    partial class EquiposControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.Button btnDescargarCSV;
        private System.Windows.Forms.DataGridView dgvEquipos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Font btnFont = new Font("Segoe UI", 9F, FontStyle.Bold);
            Color primaryColor = Color.SteelBlue;
            Color secondaryColor = Color.MediumSlateBlue;


            this.panelFiltros = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            this.btnDescargarCSV = new System.Windows.Forms.Button();
            this.dgvEquipos = new System.Windows.Forms.DataGridView();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.SuspendLayout();

            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.LightGray;
            this.panelFiltros.Controls.Add(this.txtNombre);
            this.panelFiltros.Controls.Add(this.txtCiudad);
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Controls.Add(this.btnAñadir);
            this.panelFiltros.Controls.Add(this.btnEditar);
            this.panelFiltros.Controls.Add(this.btnEliminar);
            this.panelFiltros.Controls.Add(this.btnCSV);
            this.panelFiltros.Controls.Add(this.btnDescargarCSV);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(800, 90);
            this.panelFiltros.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(10, 10);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(150, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(170, 10);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(150, 20);
            this.txtCiudad.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(330, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAñadir
            // 
            this.btnAñadir.Location = new System.Drawing.Point(10, 50);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(75, 23);
            this.btnAñadir.TabIndex = 3;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(95, 50);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(180, 50);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(265, 50);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(100, 23);
            this.btnCSV.TabIndex = 6;
            this.btnCSV.Text = "Importar CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);

            // 
            // btnDescargarCSV
            // 
            this.btnDescargarCSV.Location = new System.Drawing.Point(370, 50);
            this.btnDescargarCSV.Name = "btnDescargarCSV";
            this.btnDescargarCSV.Size = new System.Drawing.Size(110, 23);
            this.btnDescargarCSV.TabIndex = 7;
            this.btnDescargarCSV.Text = "Descargar CSV";
            this.btnDescargarCSV.UseVisualStyleBackColor = true;
            this.btnDescargarCSV.Click += new System.EventHandler(this.btnDescargarCSV_Click);
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipos.BorderStyle = BorderStyle.None;
            this.dgvEquipos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEquipos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipos.EnableHeadersVisualStyles = false;
            this.dgvEquipos.GridColor = Color.LightGray;
            this.dgvEquipos.Dock = DockStyle.Fill;
            this.dgvEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.Location = new Point(0, 90);
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipos.Size = new Size(800, 410);
            this.dgvEquipos.TabIndex = 1;
            this.dgvEquipos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellDoubleClick);
            this.dgvEquipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellContentClick);
            // Estilos adicionales para cabecera y filas
            this.dgvEquipos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 90, 130);
            this.dgvEquipos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvEquipos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvEquipos.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            this.dgvEquipos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 140, 180);
            this.dgvEquipos.DefaultCellStyle.SelectionForeColor = Color.White;
            // 
            // EquiposControl
            // 
            this.Controls.Add(this.dgvEquipos);
            this.Controls.Add(this.panelFiltros);
            this.Name = "EquiposControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.ResumeLayout(false);


            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = btnFont;
            this.btnBuscar.BackColor = primaryColor;
            this.btnBuscar.ForeColor = Color.White;
            this.btnBuscar.FlatStyle = FlatStyle.Flat;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.Location = new System.Drawing.Point(330, 10);
            this.btnBuscar.Size = new System.Drawing.Size(80, 30);

            // 
            // btnAñadir
            // 
            this.btnAñadir.Font = btnFont;
            this.btnAñadir.BackColor = secondaryColor;
            this.btnAñadir.ForeColor = Color.White;
            this.btnAñadir.FlatStyle = FlatStyle.Flat;
            this.btnAñadir.FlatAppearance.BorderSize = 0;
            this.btnAñadir.Location = new System.Drawing.Point(10, 50);
            this.btnAñadir.Size = new System.Drawing.Size(80, 30);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = btnFont;
            this.btnEditar.BackColor = primaryColor;
            this.btnEditar.ForeColor = Color.White;
            this.btnEditar.FlatStyle = FlatStyle.Flat;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.Location = new System.Drawing.Point(95, 50);
            this.btnEditar.Size = new System.Drawing.Size(80, 30);

            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = btnFont;
            this.btnEliminar.BackColor = Color.IndianRed;
            this.btnEliminar.ForeColor = Color.White;
            this.btnEliminar.FlatStyle = FlatStyle.Flat;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Location = new System.Drawing.Point(180, 50);
            this.btnEliminar.Size = new System.Drawing.Size(80, 30);

            // 
            // btnCSV
            // 
            this.btnCSV.Font = btnFont;
            this.btnCSV.BackColor = Color.DarkOliveGreen;
            this.btnCSV.ForeColor = Color.White;
            this.btnCSV.FlatStyle = FlatStyle.Flat;
            this.btnCSV.FlatAppearance.BorderSize = 0;
            this.btnCSV.Location = new System.Drawing.Point(265, 50);
            this.btnCSV.Size = new System.Drawing.Size(100, 30);

            // 
            // btnDescargarCSV
            // 
            this.btnDescargarCSV.Font = btnFont;
            this.btnDescargarCSV.BackColor = Color.Teal;
            this.btnDescargarCSV.ForeColor = Color.White;
            this.btnDescargarCSV.FlatStyle = FlatStyle.Flat;
            this.btnDescargarCSV.FlatAppearance.BorderSize = 0;
            this.btnDescargarCSV.Location = new System.Drawing.Point(370, 50);
            this.btnDescargarCSV.Size = new System.Drawing.Size(120, 30);
        }
    }
}
