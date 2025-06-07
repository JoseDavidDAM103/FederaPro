namespace FederaProDesktop
{
    partial class CompeticionesControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAñadir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();

            this.panelFiltros.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.LightGray;
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Height = 70;
            this.panelFiltros.Controls.Add(this.txtNombre);
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Controls.Add(this.btnAñadir);

            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(10, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 27);
            this.txtNombre.TabIndex = 0;

            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(220, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 27);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;

            // 
            // btnAñadir
            // 
            this.btnAñadir.Location = new System.Drawing.Point(310, 20);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(80, 27);
            this.btnAñadir.TabIndex = 2;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);

            // 
            // CompeticionesControl
            // 
            this.Controls.Add(this.panelFiltros);
            this.Name = "CompeticionesControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}