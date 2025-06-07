using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.DTOs
{
    public class UsuarioRegistroRequest
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; } = "usuario";
        public int IdDeporte { get; set; }
    }
}
