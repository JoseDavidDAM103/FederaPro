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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblConfirmar = new System.Windows.Forms.Label();
            this.txtConfirmar = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            // Form configuration
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Text = "Registro de Usuario - FederaPro";

            // Labels and TextBoxes
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(30, 30);
            this.txtNombre.Location = new System.Drawing.Point(150, 27);
            this.txtNombre.Size = new System.Drawing.Size(200, 20);

            this.lblApellido.Text = "Apellido:";
            this.lblApellido.Location = new System.Drawing.Point(30, 70);
            this.txtApellido.Location = new System.Drawing.Point(150, 67);
            this.txtApellido.Size = new System.Drawing.Size(200, 20);

            this.lblCorreo.Text = "Correo electrónico:";
            this.lblCorreo.Location = new System.Drawing.Point(30, 110);
            this.txtCorreo.Location = new System.Drawing.Point(150, 107);
            this.txtCorreo.Size = new System.Drawing.Size(200, 20);

            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.Location = new System.Drawing.Point(30, 150);
            this.txtUsuario.Location = new System.Drawing.Point(150, 147);
            this.txtUsuario.Size = new System.Drawing.Size(200, 20);

            this.lblContrasena.Text = "Contraseña:";
            this.lblContrasena.Location = new System.Drawing.Point(30, 190);
            this.txtContrasena.Location = new System.Drawing.Point(150, 187);
            this.txtContrasena.Size = new System.Drawing.Size(200, 20);
            this.txtContrasena.UseSystemPasswordChar = true;

            this.lblConfirmar.Text = "Confirmar contraseña:";
            this.lblConfirmar.Location = new System.Drawing.Point(30, 230);
            this.txtConfirmar.Location = new System.Drawing.Point(150, 227);
            this.txtConfirmar.Size = new System.Drawing.Size(200, 20);
            this.txtConfirmar.UseSystemPasswordChar = true;

            this.btnRegistrar.Text = "Registrarse";
            this.btnRegistrar.Location = new System.Drawing.Point(150, 280);
            this.btnRegistrar.Size = new System.Drawing.Size(100, 30);
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(260, 280);
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // Add controls
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.lblConfirmar);
            this.Controls.Add(this.txtConfirmar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnCancelar);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}