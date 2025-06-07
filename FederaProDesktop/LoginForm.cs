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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Pase lo que pase, abrimos el MainForm (simulación)
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide(); // Ocultamos el login

            // Opcional: cerrar completamente LoginForm cuando se cierre el MainForm
            mainForm.FormClosed += (s, args) => this.Close();
        }
    }
}
