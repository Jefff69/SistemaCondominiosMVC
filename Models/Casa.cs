
namespace SistemaCondominiosMVC.Models
{
    public class Casa
    {
        public int IdCasa { get; set; }

        public string NombreCasa { get; set; }

        public decimal MetrosCuadrados { get; set; }

        public int NumeroHabitaciones { get; set; }

        public int NumeroBanos { get; set; }

        public decimal Precio { get; set; }

        public string NombrePropietario { get; set; }

        public string ApellidoPropietario { get; set; }

        public string EmailPropietario { get; set; }
    }
}
