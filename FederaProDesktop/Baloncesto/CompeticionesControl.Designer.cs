namespace FederaProDesktop
{
    partial class CompeticionesControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Button btnAñadir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnAñadir = new System.Windows.Forms.Button();

            this.panelFiltros.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.LightGray;
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Height = 70;
            this.panelFiltros.Controls.Add(this.btnAñadir);

            // 
            // btnAñadir
            // 
            this.btnAñadir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAñadir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAñadir.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAñadir.ForeColor = System.Drawing.Color.White;
            this.btnAñadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAñadir.FlatAppearance.BorderSize = 0;
            this.btnAñadir.Location = new System.Drawing.Point(10, 20);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(120, 30);
            this.btnAñadir.TabIndex = 0;
            this.btnAñadir.Text = "+ Añadir";
            this.btnAñadir.UseVisualStyleBackColor = false;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);

            // 
            // CompeticionesControl
            // 
            this.Controls.Add(this.panelFiltros);
            this.Name = "CompeticionesControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.panelFiltros.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}