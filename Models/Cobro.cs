
using System;

namespace SistemaCondominiosMVC.Models
{
    // Representa un cobro registrado en el sistema de condominios.
    public class Cobro
    {
        // Identificador único del cobro.
        public int IdCobro { get; set; }

        // Identificador de la casa a la que pertenece el cobro.
        public int IdCasa { get; set; }

        // Mes al que corresponde el cobro, del 1 al 12.
        public int Mes { get; set; }

        // Año al que corresponde el cobro.
        public int Anno { get; set; }

        // Identificador de la bitácora; puede no estar registrado.
        public int? IdBitacora { get; set; }

        // Estado actual del cobro, por ejemplo, pendiente o pagado.
        public string Estado { get; set; }

        // Monto total del cobro.
        public decimal Monto { get; set; }

        // Fecha en que se pagó; puede ser nula si aún no se ha pagado.
        public DateTime? FechaPagada { get; set; }


        // Nombre de la casa asociada al cobro.
        public string NombreCasa { get; set; }

        // Nombre y apellido del propietario de la casa.
        public string NombrePropietario { get; set; }

        public string ApellidoPropietario { get; set; }

    }
}
