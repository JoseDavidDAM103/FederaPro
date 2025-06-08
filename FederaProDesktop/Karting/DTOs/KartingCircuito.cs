using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.Karting.DTOs
{
    public class KartingCircuito
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Ubicacion { get; set; }

        public decimal? Longitud { get; set; }

        public string Pais { get; set; }
    }
}
