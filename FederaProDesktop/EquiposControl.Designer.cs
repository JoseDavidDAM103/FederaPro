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
            // 
            // btnAñadir
            // 
            this.btnAñadir.Location = new System.Drawing.Point(10, 50);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(75, 23);
            this.btnAñadir.TabIndex = 3;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(95, 50);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(180, 50);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
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
        }
    }
}
