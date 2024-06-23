using Microsoft.EntityFrameworkCore;
using MyAngularApp.Data;
using MyAngularApp.models;
using MyAngularApp.models.request;
using MyAngularApp.models.response;

// namespace MyAngularApp.services;
public class AuthService : IAuthService
{
    private readonly MyDbContext _context;
    private readonly ILogger<AuthService> _logger;

    public AuthService(MyDbContext context, ILogger<AuthService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task<User> FindByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<GenericResponse> RegisterUserAsync(RegisterReqDto regDto)
    {

        try
        {
            _logger.LogInformation("Registering User...");
            // Check if the username or email already exists
            if (await _context.Users.AnyAsync(u => u.Username == regDto.Username))
            {
                return new GenericResponse(400, "Username already exists", null);
            }

            if (await _context.Users.AnyAsync(u => u.Email == regDto.Email))
            {
                return new GenericResponse(400, "Email already exists", null);
            }

            // Create a new user
            var user = new User
            {
                Username = regDto.Username,
                Email = regDto.Email,
                // Password = BCrypt.Net.BCrypt.HashPassword(regDto.Password) // Use a proper hashing method
                Password = regDto.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new GenericResponse(201, "User registered successfully", user);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error When Registering User");
            return new GenericResponse(500, "Error When Registering User");
        }
    }

    // public Task<GenericResponse> RegisterUserAsync(RegisterReqDto regDto)
    // {
    //     throw new NotImplementedException();
    // }
}