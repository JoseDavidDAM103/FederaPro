using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.DTOs
{
    public class LoginRequest
    {
        public string Correo { get; set; }
        public string Contraseña { get; set; }
    }

    public class LoginResponse
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public int IdDeporte { get; set; }
        public string NombreDeporte { get; set; }
    }
}
