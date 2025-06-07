using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FederaProDesktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            RegistroForm registroForm = new RegistroForm();
            registroForm.ShowDialog(); // Muestra el formulario de registro como modal
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string correo = txtUsuario.Text.Trim();
            string contraseña = txtContrasena.Text;

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, ingresa correo y contraseña.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var api = new UsuarioApiService();
            var loginResponse = await api.LoginAsync(correo, contraseña);

            if (loginResponse == null)
            {
                MessageBox.Show("Correo o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Redirección según el deporte
            Form mainForm;

            switch (loginResponse.NombreDeporte.ToLower())
            {
                case "baloncesto":
                    mainForm = new MainForm();
                    break;
                case "karting fia":
                    mainForm = new FederaProDesktop.Karting.MainKartingForm();
                    break;
                default:
                    MessageBox.Show("El deporte asignado no está soportado actualmente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            mainForm.Show();
            this.Hide();
            mainForm.FormClosed += (s, args) => this.Close();
        }
    }
}
