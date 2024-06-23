using MyAngularApp.models;
using MyAngularApp.models.request;
using MyAngularApp.models.response;
using System.Collections.Generic;
using System.Threading.Tasks;

// namespace MyAngularApp.services;
public interface IAuthService
{
    // Task<User> FindByUsernameAsync(string username);
    // Task<User> FindByEmailAsync(string email);
    // Task<IEnumerable<User>> GetUsersAsync();
    Task<GenericResponse> RegisterUserAsync(RegisterReqDto regDto);
}
