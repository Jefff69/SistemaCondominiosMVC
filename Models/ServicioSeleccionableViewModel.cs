
namespace SistemaCondominiosMVC.Models
{
    // Representa un servicio que se puede seleccionar al crear un cobro.
    public class ServicioSeleccionableViewModel
    {
        // Identificador del servicio en la base de datos.
        public int IdServicio { get; set; }

        // Nombre que verá el usuario en el formulario.
        public string Nombre { get; set; }

        // Precio del servicio.
        public decimal Precio { get; set; }

        // Indica si el usuario marcó el checkbox.
        public bool Seleccionado { get; set; }
    }
}
