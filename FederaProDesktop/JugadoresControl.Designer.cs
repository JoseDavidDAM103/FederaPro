namespace FederaProDesktop
{
    partial class JugadoresControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDorsal;
        private System.Windows.Forms.TextBox txtPosicion;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvJugadores;


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
            this.txtDorsal = new System.Windows.Forms.TextBox();
            this.txtPosicion = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvJugadores = new System.Windows.Forms.DataGridView();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.LightGray;
            this.panelFiltros.Controls.Add(this.txtNombre);
            this.panelFiltros.Controls.Add(this.txtDorsal);
            this.panelFiltros.Controls.Add(this.txtPosicion);
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Controls.Add(this.btnAñadir);
            this.panelFiltros.Controls.Add(this.btnEditar);
            this.panelFiltros.Controls.Add(this.btnEliminar);
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
            // txtDorsal
            // 
            this.txtDorsal.Location = new System.Drawing.Point(170, 10);
            this.txtDorsal.Name = "txtDorsal";
            this.txtDorsal.Size = new System.Drawing.Size(100, 20);
            this.txtDorsal.TabIndex = 1;
            // 
            // txtPosicion
            // 
            this.txtPosicion.Location = new System.Drawing.Point(280, 10);
            this.txtPosicion.Name = "txtPosicion";
            this.txtPosicion.Size = new System.Drawing.Size(120, 20);
            this.txtPosicion.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(410, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnAñadir
            // 
            this.btnAñadir.Location = new System.Drawing.Point(10, 50);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(75, 23);
            this.btnAñadir.TabIndex = 4;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(95, 50);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(180, 50);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // dgvJugadores
            // 
            this.dgvJugadores.BackgroundColor = System.Drawing.Color.White;
            this.dgvJugadores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvJugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJugadores.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.LightGray,
                ForeColor = Color.Black
            };
            this.dgvJugadores.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 10F),
                SelectionBackColor = Color.FromArgb(60, 90, 130),
                SelectionForeColor = Color.White
            };
            this.dgvJugadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJugadores.GridColor = System.Drawing.Color.LightGray;
            this.dgvJugadores.Location = new System.Drawing.Point(0, 90);
            this.dgvJugadores.Name = "dgvJugadores";
            this.dgvJugadores.RowHeadersVisible = false;
            this.dgvJugadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJugadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJugadores.Size = new System.Drawing.Size(800, 410);
            this.dgvJugadores.TabIndex = 1;
            this.dgvJugadores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJugadores_CellDoubleClick);
            // 
            // JugadoresControl
            // 
            this.Controls.Add(this.dgvJugadores);
            this.Controls.Add(this.panelFiltros);
            this.Name = "JugadoresControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
