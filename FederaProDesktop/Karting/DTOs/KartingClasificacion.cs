using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.Karting.DTOs
{
    public class KartingClasificacionEquipoDTO
    {
        public string Equipo { get; set; }
        public int Puntos { get; set; }
    }

    public class KartingClasificacionPilotoDTO
    {
        public string Piloto { get; set; }
        public string Equipo { get; set; }
        public int Puntos { get; set; }
    }
}
