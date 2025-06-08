using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.Karting.DTOs
{
    public class KartingEstadisticaPilotoDTO
    {
        public string NombrePiloto { get; set; }
        public int IdCarrera { get; set; }
        public int Posicion { get; set; }
        public decimal TiempoTotal { get; set; }
        public int Vueltas { get; set; }
    }
}
