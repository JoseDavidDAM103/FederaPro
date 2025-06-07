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

            // txtNombre
            this.txtNombre.Location = new Point(100, 20);
            this.txtNombre.Size = new Size(200, 23);

            // lblTipo
            this.lblTipo.Text = "Tipo:";
            this.lblTipo.Location = new Point(20, 60);

            // txtTipo
            this.txtTipo.Location = new Point(100, 60);
            this.txtTipo.Size = new Size(200, 23);

            // lblEquipos
            this.lblEquipos.Text = "Equipos:";
            this.lblEquipos.Location = new Point(20, 100);

            // lstEquipos
            this.lstEquipos.Location = new Point(100, 100);
            this.lstEquipos.Size = new Size(200, 150);
            this.lstEquipos.SelectionMode = SelectionMode.MultiExtended;

            // btnGuardar
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new Point(100, 270);
            this.btnGuardar.Click += new EventHandler(btnGuardar_Click);

            // CrearCompeticion
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.lblEquipos);
            this.Controls.Add(this.lstEquipos);
            this.Controls.Add(this.btnGuardar);
            this.Size = new Size(400, 320);

            this.ResumeLayout(false);
        }
    }
}
