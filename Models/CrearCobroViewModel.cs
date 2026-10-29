
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaCondominiosMVC.Models
{
    // Modelo que representa el formulario para crear un cobro.
    public class CrearCobroViewModel
    {
        // Cliente al que se le generará el cobro.
        [Required(ErrorMessage = "Debe seleccionar un cliente.")]
        public int? IdPersona { get; set; }

        // Casa asociada al cliente seleccionado.
        [Required(ErrorMessage = "Debe seleccionar una casa.")]
        public int? IdCasa { get; set; }

        // Año del cobro, entre 2024 y 2034.
        [Required(ErrorMessage = "Debe seleccionar un año.")]
        [Range(2024, 2034, ErrorMessage = "El año debe estar entre 2024 y 2034.")]
        public int? Anno { get; set; }

        // Mes del cobro, de enero a diciembre.
        [Required(ErrorMessage = "Debe seleccionar un mes.")]
        [Range(1, 12, ErrorMessage = "Debe seleccionar un mes válido.")]
        public int? Mes { get; set; }

        // Identificadores de los servicios seleccionados.
        [Required(ErrorMessage = "Debe seleccionar al menos un servicio.")]
        [MinLength(1, ErrorMessage = "Debe seleccionar al menos un servicio.")]
        public List<int> ServiciosSeleccionados { get; set; }
            = new List<int>();
    }
}
