using Catedra3Backend.Src.DTOs;
using Catedra3Backend.Src.Models;
using Catedra3Backend.Src.Repositories.Interfaces;
using Catedra3Backend.Src.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Catedra3Backend.Src.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;

        public AuthController(IUserRepository userRepository, ITokenService tokenService, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return BadRequest("Email ya registrado");
            }

            var user = new User
            {
                Email = registerDto.Email,
                UserName = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(e => e.Description));
            }

            return Ok("Usuario registrado exitosamente");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);

            if (user == null || user.PasswordHash != loginDto.Password)
            {
                return BadRequest("Credenciales inválidas");
            }

            var token = _tokenService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }
    }
}