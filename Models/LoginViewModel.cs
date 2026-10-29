
using System.ComponentModel.DataAnnotations;

namespace SistemaCondominiosMVC.Models
{
    // Representa los datos que el usuario introduce en el login.
    public class LoginViewModel
    {
        // Correo electrónico requerido para iniciar sesión.
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Introduce un correo electrónico válido.")]
        public string Email { get; set; }

        // Contraseña requerida para validar las credenciales.
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
    }
}
