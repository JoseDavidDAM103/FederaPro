using System;
using System.Windows.Forms;

namespace FederaProDesktop
{
    public partial class LoginForm : Form
    {

        private void InitializeComponent()
        {
            this.lblUsuario = new Label();
            this.lblContrasena = new Label();
            this.txtUsuario = new TextBox();
            this.txtContrasena = new TextBox();
            this.btnLogin = new Button();
            this.btnRegistro = new Button();
            this.logoImage = new PictureBox();

            this.SuspendLayout();

            // Logo
            this.logoImage.Image = Image.FromFile("ic_logo.png");
            this.logoImage.Location = new Point(117, 10);
            this.logoImage.Size = new Size(100, 100);
            this.logoImage.SizeMode = PictureBoxSizeMode.Zoom;

            // Usuario
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.Location = new Point(30, 130);
            this.txtUsuario.Location = new Point(120, 127);
            this.txtUsuario.Size = new Size(160, 20);

            // Contraseña
            this.lblContrasena.Text = "Contraseña:";
            this.lblContrasena.Location = new Point(30, 170);
            this.txtContrasena.Location = new Point(120, 167);
            this.txtContrasena.Size = new Size(160, 20);
            this.txtContrasena.UseSystemPasswordChar = true;

            // Botón Login
            this.btnLogin.Text = "Iniciar sesión";
            this.btnLogin.Location = new Point(120, 210);
            this.btnLogin.Size = new Size(160, 30);
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // Botón Registro
            this.btnRegistro.Text = "Registrarse";
            this.btnRegistro.Location = new Point(120, 250);
            this.btnRegistro.Size = new Size(160, 30);
            this.btnRegistro.Click += new EventHandler(this.btnRegistro_Click);

            // Form
            this.ClientSize = new Size(340, 310);
            this.Controls.Add(this.logoImage);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegistro);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Text = "FederaPro - Inicio de Sesión";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.PictureBox logoImage;
    }
}
