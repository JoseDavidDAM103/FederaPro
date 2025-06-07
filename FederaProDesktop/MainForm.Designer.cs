namespace FederaProDesktop
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelMenuTop;
        private System.Windows.Forms.Panel panelMenuBottom;
        private System.Windows.Forms.Panel panelContenido;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelMenuTop = new System.Windows.Forms.Panel();
            this.panelMenuBottom = new System.Windows.Forms.Panel();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            this.panelMenu.Controls.Add(this.panelMenuTop);
            this.panelMenu.Controls.Add(this.panelMenuBottom);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(180, 600);
            this.panelMenu.TabIndex = 0;
            // 
            // panelMenuTop
            // 
            this.panelMenuTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenuTop.Location = new System.Drawing.Point(0, 0);
            this.panelMenuTop.Name = "panelMenuTop";
            this.panelMenuTop.Size = new System.Drawing.Size(180, 540);
            this.panelMenuTop.TabIndex = 0;
            // 
            // panelMenuBottom
            // 
            this.panelMenuBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMenuBottom.Location = new System.Drawing.Point(0, 540);
            this.panelMenuBottom.Name = "panelMenuBottom";
            this.panelMenuBottom.Size = new System.Drawing.Size(180, 60);
            this.panelMenuBottom.TabIndex = 1;
            // 
            // panelContenido
            // 
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(180, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(820, 600);
            this.panelContenido.TabIndex = 1;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelMenu);
            this.Name = "MainForm";
            this.Text = "FederaPro - Baloncesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}