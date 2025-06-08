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
        public DateTime? FechaNacimiento { get; set; } // Sustituye a Edad
        public string Categoria { get; set; }
        public int? NumeroKart { get; set; }
        public int? EquipoId { get; set; }
        public string NombreEquipo { get; set; }
    }
}
