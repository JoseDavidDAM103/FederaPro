using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.Modelos.DTO
{
    public class BasketJugadoreDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Posicion { get; set; }
        public int Dorsal { get; set; }
        public BasketEquipoDTO Equipo { get; set; }

        public string NombreEquipo
        {
            get => Equipo?.Nombre ?? _nombreEquipo;
            set
            {
                _nombreEquipo = value;
                if (Equipo == null)
                    Equipo = new BasketEquipoDTO();
                Equipo.Nombre = value;
            }
        }
        private string _nombreEquipo;
    }

    public class CrearActualizarJugadorDTO
    {
        public int? id { get; set; }
        public string nombre { get; set; }
        public double altura { get; set; }
        public double peso { get; set; }
        public string posicion { get; set; }
        public int dorsal { get; set; }
        public int equipoId { get; set; }
    }
}
