namespace FederaProDesktop
{
    partial class RegistroForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblConfirmar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtConfirmar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnCancelar;

        private void InitializeComponent()
        {
            this.lblNombre = new Label();
            this.txtNombre = new TextBox();
            this.lblApellido = new Label();
            this.txtApellido = new TextBox();
            this.lblCorreo = new Label();
            this.txtCorreo = new TextBox();
            this.lblUsuario = new Label();
            this.txtUsuario = new TextBox();
            this.lblContrasena = new Label();
            this.txtContrasena = new TextBox();
            this.lblConfirmar = new Label();
            this.txtConfirmar = new TextBox();
            this.btnRegistrar = new Button();
            this.btnCancelar = new Button();

            // Form
            this.SuspendLayout();
            this.ClientSize = new Size(450, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Text = "Registro de Usuario - FederaPro";
            this.BackColor = Color.White;

            Font labelFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            Font inputFont = new Font("Segoe UI", 10F);

            int labelX = 30, inputX = 180, width = 220, height = 26;
            int topOffset = 30, spacing = 40;

            // Estilo para todos los Labels y TextBox
            void Estilizar(Label lbl, string text, int y)
            {
                lbl.Text = text;
                lbl.Location = new Point(labelX, y);
                lbl.Size = new Size(140, height);
                lbl.Font = labelFont;
            }

            void EstilizarTxt(TextBox txt, int y)
            {
                txt.Location = new Point(inputX, y);
                txt.Size = new Size(width, height);
                txt.Font = inputFont;
                txt.BorderStyle = BorderStyle.FixedSingle;
            }

            // Controles
            Estilizar(lblNombre, "Nombre:", topOffset);
            EstilizarTxt(txtNombre, topOffset);

            Estilizar(lblApellido, "Apellido:", topOffset + spacing);
            EstilizarTxt(txtApellido, topOffset + spacing);

            Estilizar(lblCorreo, "Correo electrónico:", topOffset + spacing * 2);
            EstilizarTxt(txtCorreo, topOffset + spacing * 2);

            Estilizar(lblUsuario, "Usuario:", topOffset + spacing * 3);
            EstilizarTxt(txtUsuario, topOffset + spacing * 3);

            Estilizar(lblContrasena, "Contraseña:", topOffset + spacing * 4);
            EstilizarTxt(txtContrasena, topOffset + spacing * 4);
            txtContrasena.UseSystemPasswordChar = true;

            Estilizar(lblConfirmar, "Confirmar contraseña:", topOffset + spacing * 5);
            EstilizarTxt(txtConfirmar, topOffset + spacing * 5);
            txtConfirmar.UseSystemPasswordChar = true;

            // Botón Registrar
            this.btnRegistrar.Text = "Registrarse";
            this.btnRegistrar.Location = new Point(inputX, topOffset + spacing * 6 + 10);
            this.btnRegistrar.Size = new Size(100, 35);
            this.btnRegistrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRegistrar.BackColor = Color.FromArgb(60, 130, 200);
            this.btnRegistrar.ForeColor = Color.White;
            this.btnRegistrar.FlatStyle = FlatStyle.Flat;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.Click += new EventHandler(this.btnRegistrar_Click);

            // Botón Cancelar
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new Point(inputX + 110, topOffset + spacing * 6 + 10);
            this.btnCancelar.Size = new Size(100, 35);
            this.btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancelar.BackColor = Color.LightGray;
            this.btnCancelar.ForeColor = Color.Black;
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            // Agregar controles
            this.Controls.AddRange(new Control[]
            {
        lblNombre, txtNombre,
        lblApellido, txtApellido,
        lblCorreo, txtCorreo,
        lblUsuario, txtUsuario,
        lblContrasena, txtContrasena,
        lblConfirmar, txtConfirmar,
        btnRegistrar, btnCancelar
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}