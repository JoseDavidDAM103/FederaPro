namespace FederaProDesktop
{
    partial class DetalleJugadorControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Button btnEstadisticas;
        private Button btnEstadisticasAnuales;
        private Panel panelBotones;
        private Panel panelContenido;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Font headerFont = new Font("Segoe UI", 14F, FontStyle.Bold);
            Font buttonFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Color buttonColor = Color.SteelBlue;
            Color buttonTextColor = Color.White;

            this.lblTitulo = new Label();
            this.btnEstadisticas = new Button();
            this.btnEstadisticasAnuales = new Button();
            this.panelBotones = new Panel();
            this.panelContenido = new Panel();

            this.panelBotones.SuspendLayout();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Dock = DockStyle.Top;
            this.lblTitulo.Font = headerFont;
            this.lblTitulo.Padding = new Padding(10);
            this.lblTitulo.Text = "Nombre del Jugador";
            this.lblTitulo.Height = 50;

            // panelBotones
            this.panelBotones.Dock = DockStyle.Top;
            this.panelBotones.Height = 50;
            this.panelBotones.BackColor = Color.LightGray;
            this.panelBotones.Padding = new Padding(10);
            this.panelBotones.Controls.Add(this.btnEstadisticas);
            this.panelBotones.Controls.Add(this.btnEstadisticasAnuales);

            // btnEstadisticas
            this.btnEstadisticas.Text = "Estadísticas";
            this.btnEstadisticas.Size = new Size(120, 30);
            this.btnEstadisticas.Location = new Point(10, 10);
            this.btnEstadisticas.Font = buttonFont;
            this.btnEstadisticas.BackColor = buttonColor;
            this.btnEstadisticas.ForeColor = buttonTextColor;
            this.btnEstadisticas.FlatStyle = FlatStyle.Flat;
            this.btnEstadisticas.FlatAppearance.BorderSize = 0;
            this.btnEstadisticas.Click += new EventHandler(this.btnEstadisticas_Click);

            // btnEstadisticasAnuales
            this.btnEstadisticasAnuales.Text = "Estadísticas del año";
            this.btnEstadisticasAnuales.Size = new Size(160, 30);
            this.btnEstadisticasAnuales.Location = new Point(140, 10);
            this.btnEstadisticasAnuales.Font = buttonFont;
            this.btnEstadisticasAnuales.BackColor = buttonColor;
            this.btnEstadisticasAnuales.ForeColor = buttonTextColor;
            this.btnEstadisticasAnuales.FlatStyle = FlatStyle.Flat;
            this.btnEstadisticasAnuales.FlatAppearance.BorderSize = 0;
            this.btnEstadisticasAnuales.Click += new EventHandler(this.btnEstadisticasAnuales_Click);

            // panelContenido
            this.panelContenido.Dock = DockStyle.Fill;
            this.panelContenido.BackColor = Color.WhiteSmoke;

            // DetalleJugadorControl
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.lblTitulo);
            this.Name = "DetalleJugadorControl";
            this.Size = new Size(800, 500);

            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
