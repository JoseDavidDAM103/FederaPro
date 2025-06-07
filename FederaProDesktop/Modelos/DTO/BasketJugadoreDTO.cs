using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.Modelos.DTO
{
    public class BasketJugadoreDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Posicion { get; set; }
        public int Dorsal { get; set; }
        public BasketEquipoDTO Equipo { get; set; }

        public string NombreEquipo => Equipo != null ? Equipo.Nombre : "";
    }
}
