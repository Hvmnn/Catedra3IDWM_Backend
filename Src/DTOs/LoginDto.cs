using System.ComponentModel.DataAnnotations;

namespace Catedra3Backend.Src.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El Correo electrónico es obligatorio.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; } = string.Empty;
    }
}