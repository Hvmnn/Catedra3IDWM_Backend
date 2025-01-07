using Microsoft.AspNetCore.Identity;

namespace Catedra3Backend.Src.Models{

    public class User : IdentityUser{
        public required string Password { get; set; }
    }
}