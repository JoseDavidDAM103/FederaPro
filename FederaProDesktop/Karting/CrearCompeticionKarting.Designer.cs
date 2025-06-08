namespace FederaProDesktop.Karting
{
    partial class CrearCompeticionKarting
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblEquipos;
        private System.Windows.Forms.CheckedListBox checkedListBoxEquipos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;


        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNombre = new TextBox();
            this.txtTipo = new TextBox();
            this.txtCategoria = new TextBox();
            this.dtpFechaInicio = new DateTimePicker();
            this.dtpFechaFin = new DateTimePicker();
            this.checkedListBoxEquipos = new CheckedListBox();
            this.btnGuardar = new Button();

            this.lblNombre = new Label();
            this.lblTipo = new Label();
            this.lblCategoria = new Label();
            this.lblFechaInicio = new Label();
            this.lblFechaFin = new Label();
            this.lblEquipos = new Label();

            // 
            // lblNombre
            // 
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.lblNombre.Location = new Point(30, 30);
            this.lblNombre.Size = new Size(120, 25);

            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(160, 30);
            this.txtNombre.Size = new Size(250, 25);

            // 
            // lblTipo
            // 
            this.lblTipo.Text = "Tipo:";
            this.lblTipo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.lblTipo.Location = new Point(30, 70);
            this.lblTipo.Size = new Size(120, 25);

            // 
            // txtTipo
            // 
            this.txtTipo.Location = new Point(160, 70);
            this.txtTipo.Size = new Size(250, 25);

            // 
            // lblCategoria
            // 
            this.lblCategoria.Text = "Categoría:";
            this.lblCategoria.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.lblCategoria.Location = new Point(30, 110);
            this.lblCategoria.Size = new Size(120, 25);

            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new Point(160, 110);
            this.txtCategoria.Size = new Size(250, 25);

            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.Text = "Fecha inicio:";
            this.lblFechaInicio.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.lblFechaInicio.Location = new Point(30, 150);
            this.lblFechaInicio.Size = new Size(120, 25);

            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new Point(160, 150);
            this.dtpFechaInicio.Size = new Size(250, 25);

            // 
            // lblFechaFin
            // 
            this.lblFechaFin.Text = "Fecha fin:";
            this.lblFechaFin.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.lblFechaFin.Location = new Point(30, 190);
            this.lblFechaFin.Size = new Size(120, 25);

            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new Point(160, 190);
            this.dtpFechaFin.Size = new Size(250, 25);

            // 
            // lblEquipos
            // 
            this.lblEquipos.Text = "Equipos participantes:";
            this.lblEquipos.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.lblEquipos.Location = new Point(30, 230);
            this.lblEquipos.Size = new Size(250, 25);

            // 
            // checkedListBoxEquipos
            // 
            this.checkedListBoxEquipos.Location = new Point(30, 260);
            this.checkedListBoxEquipos.Size = new Size(380, 120);
            this.checkedListBoxEquipos.Font = new Font("Segoe UI", 9);

            // 
            // btnGuardar
            // 
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.BackColor = Color.DarkSlateBlue;
            this.btnGuardar.ForeColor = Color.White;
            this.btnGuardar.FlatStyle = FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnGuardar.Location = new Point(30, 400);
            this.btnGuardar.Size = new Size(120, 40);
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            // 
            // CrearCompeticionKarting
            // 
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.lblEquipos);
            this.Controls.Add(this.checkedListBoxEquipos);
            this.Controls.Add(this.btnGuardar);

            this.Size = new Size(460, 470);
        }
    }
}