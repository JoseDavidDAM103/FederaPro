using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.Karting.DTOs
{
    public class KartingCarrera
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int IdCompeticion { get; set; }
        public string NombreCompeticion { get; set; }  

        public int IdCircuito { get; set; }
        public string NombreCircuito { get; set; }    
    }

    public class KartingCarreraDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Circuito { get; set; }
        public int Numero { get; set; } // si aplica
    }
}
