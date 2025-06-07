using FederaProDesktop.DTOs;
using System;
using System.Windows.Forms;

namespace FederaProDesktop
{
    public partial class RegistroForm : Form
    {
        public RegistroForm()
        {
            InitializeComponent();
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtContrasena.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            var api = new UsuarioApiService();
            bool existe = await api.ExisteCorreoAsync(txtCorreo.Text.Trim());
            if (existe)
            {
                MessageBox.Show("Ya existe un usuario con ese correo.");
                return;
            }

            // Datos básicos OK → pasar al formulario de deporte
            var usuarioNuevo = new UsuarioRegistroRequest
            {
                Nombre = txtNombre.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Contraseña = txtContrasena.Text,
                Rol = "usuario"
            };

            var selector = new SeleccionDeporteForm(usuarioNuevo);
            selector.ShowDialog();

            if (selector.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Usuario registrado correctamente.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
