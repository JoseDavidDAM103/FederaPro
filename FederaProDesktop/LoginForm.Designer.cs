using System;
using System.Drawing;
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

            // Fuente común
            var fuente = new Font("Segoe UI", 10);

            // Logo
            this.logoImage.Image = Image.FromFile("ic_logo.png");
            this.logoImage.Location = new Point(120, 20);
            this.logoImage.Size = new Size(100, 100);
            this.logoImage.SizeMode = PictureBoxSizeMode.Zoom;

            // Usuario
            this.lblUsuario.Text = "Correo:";
            this.lblUsuario.Font = fuente;
            this.lblUsuario.Location = new Point(40, 140);
            this.lblUsuario.Size = new Size(70, 25);
            this.txtUsuario.Font = fuente;
            this.txtUsuario.Location = new Point(120, 140);
            this.txtUsuario.Size = new Size(160, 25);

            // Contraseña
            this.lblContrasena.Text = "Contraseña:";
            this.lblContrasena.Font = fuente;
            this.lblContrasena.Location = new Point(20, 180);
            this.lblContrasena.Size = new Size(90, 25);
            this.txtContrasena.Font = fuente;
            this.txtContrasena.Location = new Point(120, 180);
            this.txtContrasena.Size = new Size(160, 25);
            this.txtContrasena.UseSystemPasswordChar = true;

            // Botón Login
            this.btnLogin.Text = "Iniciar sesión";
            this.btnLogin.Font = fuente;
            this.btnLogin.Location = new Point(120, 230);
            this.btnLogin.Size = new Size(160, 35);
            this.btnLogin.BackColor = Color.LightSeaGreen;
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // Botón Registro
            this.btnRegistro.Text = "Registrarse";
            this.btnRegistro.Font = fuente;
            this.btnRegistro.Location = new Point(120, 280);
            this.btnRegistro.Size = new Size(160, 35);
            this.btnRegistro.BackColor = Color.LightSlateGray;
            this.btnRegistro.ForeColor = Color.White;
            this.btnRegistro.FlatStyle = FlatStyle.Flat;
            this.btnRegistro.Cursor = Cursors.Hand;
            this.btnRegistro.Click += new EventHandler(this.btnRegistro_Click);

            // Form
            this.ClientSize = new Size(340, 360);
            this.BackColor = Color.White;
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

        private Label lblUsuario;
        private Label lblContrasena;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnLogin;
        private Button btnRegistro;
        private PictureBox logoImage;
    }
}