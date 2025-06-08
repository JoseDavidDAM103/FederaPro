namespace FederaProDesktop.Karting
{
    partial class CompeticionesKartingControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnAñadir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 70;
            this.panelTop.Controls.Add(this.btnAñadir);

            // 
            // btnAñadir
            // 
            this.btnAñadir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAñadir.BackColor = System.Drawing.Color.Firebrick;
            this.btnAñadir.ForeColor = System.Drawing.Color.White;
            this.btnAñadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAñadir.FlatAppearance.BorderSize = 0;
            this.btnAñadir.Location = new System.Drawing.Point(20, 20);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(120, 30);
            this.btnAñadir.TabIndex = 0;
            this.btnAñadir.Text = "+ Añadir";
            this.btnAñadir.UseVisualStyleBackColor = false;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);

            // 
            // CompeticionesKartingControl
            // 
            this.Controls.Add(this.panelTop);
            this.Name = "CompeticionesKartingControl";
            this.Size = new System.Drawing.Size(800, 500);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}