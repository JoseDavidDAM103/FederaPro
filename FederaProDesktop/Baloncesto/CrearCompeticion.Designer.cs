namespace FederaProDesktop
{
    partial class CrearCompeticion
    {
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblTipo;
        private TextBox txtTipo;
        private Label lblEquipos;
        private ListBox lstEquipos;
        private Button btnGuardar;

        private void InitializeComponent()
        {
            Font labelFont = new Font("Segoe UI", 10F);
            Font inputFont = new Font("Segoe UI", 10F);
            Font buttonFont = new Font("Segoe UI", 9F, FontStyle.Bold);

            Color mainButtonColor = Color.SteelBlue;
            Color textColor = Color.White;

            this.lblNombre = new Label();
            this.txtNombre = new TextBox();
            this.lblTipo = new Label();
            this.txtTipo = new TextBox();
            this.lblEquipos = new Label();
            this.lstEquipos = new ListBox();
            this.btnGuardar = new Button();

            this.SuspendLayout();

            // lblNombre
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new Point(20, 20);
            this.lblNombre.Size = new Size(70, 23);
            this.lblNombre.Font = labelFont;

            // txtNombre
            this.txtNombre.Location = new Point(100, 20);
            this.txtNombre.Size = new Size(250, 27);
            this.txtNombre.Font = inputFont;

            // lblTipo
            this.lblTipo.Text = "Tipo:";
            this.lblTipo.Location = new Point(20, 60);
            this.lblTipo.Size = new Size(70, 23);
            this.lblTipo.Font = labelFont;

            // txtTipo
            this.txtTipo.Location = new Point(100, 60);
            this.txtTipo.Size = new Size(250, 27);
            this.txtTipo.Font = inputFont;

            // lblEquipos
            this.lblEquipos.Text = "Equipos:";
            this.lblEquipos.Location = new Point(20, 100);
            this.lblEquipos.Size = new Size(70, 23);
            this.lblEquipos.Font = labelFont;

            // lstEquipos
            this.lstEquipos.Location = new Point(100, 100);
            this.lstEquipos.Size = new Size(250, 150);
            this.lstEquipos.SelectionMode = SelectionMode.MultiExtended;
            this.lstEquipos.Font = inputFont;
            this.lstEquipos.BorderStyle = BorderStyle.FixedSingle;

            // btnGuardar
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new Point(100, 270);
            this.btnGuardar.Size = new Size(120, 35);
            this.btnGuardar.Font = buttonFont;
            this.btnGuardar.BackColor = mainButtonColor;
            this.btnGuardar.ForeColor = textColor;
            this.btnGuardar.FlatStyle = FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Click += new EventHandler(btnGuardar_Click);

            // CrearCompeticion
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.lblEquipos);
            this.Controls.Add(this.lstEquipos);
            this.Controls.Add(this.btnGuardar);
            this.Size = new Size(400, 330);
            this.BackColor = Color.WhiteSmoke;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
