using Catedra3Backend.Src.Models;

namespace Catedra3Backend.Src.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
    }
}