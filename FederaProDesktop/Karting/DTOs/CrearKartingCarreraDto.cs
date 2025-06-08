using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.Karting.DTOs
{
    public class CrearKartingCarreraDto
    {
        public string nombreCompeticion { get; set; }
        public long circuitoId { get; set; }
        public DateTime fecha { get; set; }
    }
}
