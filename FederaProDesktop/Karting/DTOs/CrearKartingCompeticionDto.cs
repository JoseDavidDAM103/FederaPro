using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.Karting.DTOs
{
    public class CrearKartingCompeticionDto
    {
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string categoria { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public List<long> equiposIds { get; set; }
    }
}
