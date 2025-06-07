using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.Karting.DTOs
{
    public class KartingPiloto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public int Edad { get; set; }
        public string Categoria { get; set; }
    }
}
