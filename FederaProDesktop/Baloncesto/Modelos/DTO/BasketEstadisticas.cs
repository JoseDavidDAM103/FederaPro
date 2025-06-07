using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.Modelos.DTO
{
    public class EstadisticasPartidoDTO
    {
        public int PartidoId { get; set; }
        public List<EstadisticaEquipoDTO> EstadisticasEquipos { get; set; }
        public List<EstadisticaJugadorDTO> EstadisticasJugadores { get; set; }
    }

    public class EstadisticaEquipoDTO
    {
        public string Equipo { get; set; }
        public int PartidoId { get; set; }
        public int Puntos { get; set; }
        public int Rebotes { get; set; }
        public int Asistencias { get; set; }
        public int Perdidas { get; set; }
        public int Tapones { get; set; }
        public int Robos { get; set; }
    }

    public class EstadisticaJugadorDTO
    {
        public int IdJugador { get; set; }
        
        public int PartidoId { get; set; }
        public int Puntos { get; set; }
        public int Rebotes { get; set; }
        public int Asistencias { get; set; }
        public int Robos { get; set; }
        public int Tapones { get; set; }
        public int Perdidas { get; set; }
        public int Minutos { get; set; }
    }
}
