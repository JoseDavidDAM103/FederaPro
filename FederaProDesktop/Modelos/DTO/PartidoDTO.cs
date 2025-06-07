using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.Modelos.DTO
{
    public class PartidoDTO
    {
        public int Jornada { get; set; }
        
        public int Id { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime Fecha { get; set; }
        public string Resultado { get; set; }
    }
}
