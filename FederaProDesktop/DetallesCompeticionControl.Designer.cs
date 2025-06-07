namespace FederaProDesktop
{
    partial class DetallesCompeticionControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Button btnEquipos;
        private Button btnPartidos;
        private Button btnClasificacion;
        private Panel panelBotones;
        private Panel panelContenido;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.btnEquipos = new Button();
            this.btnPartidos = new Button();
            this.btnClasificacion = new Button();
            this.panelBotones = new Panel();
            this.panelContenido = new Panel();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = DockStyle.Top;
            this.lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitulo.Padding = new Padding(10);
            this.lblTitulo.Text = "Título de la competición";
            this.lblTitulo.Height = 50;
            // 
            // panelBotones
            // 
            this.panelBotones.Dock = DockStyle.Top;
            this.panelBotones.Height = 40;
            this.panelBotones.BackColor = Color.LightGray;
            this.panelBotones.Controls.Add(this.btnEquipos);
            this.panelBotones.Controls.Add(this.btnPartidos);
            this.panelBotones.Controls.Add(this.btnClasificacion);
            // 
            // btnEquipos
            // 
            this.btnEquipos.Text = "Equipos";
            this.btnEquipos.Width = 100;
            this.btnEquipos.Location = new Point(10, 7);
            this.btnEquipos.Click += new EventHandler(this.btnEquipos_Click);
            // 
            // btnPartidos
            // 
            this.btnPartidos.Text = "Partidos";
            this.btnPartidos.Width = 100;
            this.btnPartidos.Location = new Point(120, 7);
            this.btnPartidos.Click += new EventHandler(this.btnPartidos_Click);
            // 
            // btnClasificacion
            // 
            this.btnClasificacion.Text = "Clasificación";
            this.btnClasificacion.Width = 100;
            this.btnClasificacion.Location = new Point(230, 7);
            this.btnClasificacion.Click += new EventHandler(this.btnClasificacion_Click);
            // 
            // panelContenido
            // 
            this.panelContenido.Dock = DockStyle.Fill;
            this.panelContenido.BackColor = Color.WhiteSmoke;
            // 
            // DetalleCompeticionControl
            // 
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.lblTitulo);
            this.Name = "DetalleCompeticionControl";
            this.Size = new Size(800, 500);
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
