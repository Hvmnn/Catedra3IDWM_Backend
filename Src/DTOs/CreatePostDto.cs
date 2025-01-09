using System.ComponentModel.DataAnnotations;

namespace Catedra3Backend.Src.DTOs
{
    public class CreatePostDto
    {
        [MinLength(5, ErrorMessage = "El Título debe tener al menos 5 caracteres.")]
        public required string Title { get; set; }

        public required IFormFile? Image { get; set; }

        public required string UserId { get; set; }
    }
}