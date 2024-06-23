// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MyAngularApp.models;
using MyAngularApp.Data;
using Microsoft.EntityFrameworkCore;
using MyAngularApp.models.response;
using MyAngularApp.models.request;

// using Microsoft.AspNetCore.Identity.Data;

namespace MyAngularApp.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly MyDbContext _context;
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, MyDbContext context, ILogger<AuthController> logger, IAuthService authService)
        {
            _configuration = configuration;
            _context = context;
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginRequest)
        {
            User? existingUser = FindUser(loginRequest);
            if (existingUser != null)
            {
                if (IsValidUser(loginRequest, existingUser))
                {
                    var token = GenerateJwtToken(loginRequest.Username);
                    return Ok(new GenericResponse(200, "Login Success", new { token }));
                }
            }
            else
            {
                return NotFound(new GenericResponse(404, "User tidak ditemukan"));
            }

            return Unauthorized(new GenericResponse(401, "Wrong Password"));
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<GenericResponse>> Register(RegisterReqDto registerDto)
        {
            try
            {
                _logger.LogInformation("New User registration request received");
                var response = await _authService.RegisterUserAsync(registerDto);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the user.");
                return StatusCode(500, new GenericResponse(500, "An error occurred while registering the user."));
            }
        }

        private User? FindUser(User loginRequest)
        {
            User? user = _context.Users.SingleOrDefault(u => u.Email == loginRequest.Email);
            if (user == null)
            {
                user = _context.Users.SingleOrDefault(u => u.Username == loginRequest.Username);
            }

            return user;
        }

        private bool IsValidUser(User loginRequest, User existingUser)
        {
            // Replace this with your user validation logic
            return loginRequest.Username == existingUser.Username && loginRequest.Password == existingUser.Password;
        }

        private string GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}