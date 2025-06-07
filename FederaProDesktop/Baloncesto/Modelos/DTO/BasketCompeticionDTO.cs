using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederaProDesktop.Modelos.DTO
{
    internal class BasketCompeticionDTO
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
    }

    public class CrearCompeticionDTO
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public List<int> EquipoIds { get; set; }
    }

    public class BasketEquipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString() => Nombre; // Para que se muestre correctamente en el CheckedListBox
    }
}
