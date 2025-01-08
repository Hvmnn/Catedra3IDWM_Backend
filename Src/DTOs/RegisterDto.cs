using System.ComponentModel.DataAnnotations;

namespace Catedra3Backend.Src.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El email no es válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Contraseña es obligatoria.")]
        [MinLength(8, ErrorMessage = "La Contraseña debe tener al menos 6 caracteres.")]
        [RegularExpression(@"^(?=.*\d).+$", ErrorMessage = "La Contraseña debe tener al menos un número.")]
        public string Password { get; set; } = string.Empty; 
    }
}