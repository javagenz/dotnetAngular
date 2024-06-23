// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using MyAngularApp.Data;
// using Swashbuckle.AspNetCore.Annotations; // Import namespace ini


// namespace MyAngularApp.Controllers
// {
//     [HttpGet]
// [Route("api/[controller]")]
// [SwaggerTag("Endpoints untuk mengelola data pengguna")]
// public class UsersController : ControllerBase
// {
//     private readonly MyDbContext _context;

//     public UsersController(MyDbContext context)
//     {
//         _context = context;
//     }

//     [HttpGet]
//     [Route("api/users")]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [Produces("application/json")]
//     public ActionResult<IEnumerable<User>> GetUsers()
//     {
//         var users = _context.Users.ToList();
//         return Ok(users);
//     }
// }

// }

using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Mvc;
using MyAngularApp.models;
using MyAngularApp.Data;
using Swashbuckle.AspNetCore.Annotations;
using MyAngularApp.models.response;

namespace MyAngularApp.Controllers
{
    [ApiController]
    [Route("api/users")]
    // [Route("api/users")]
    [SwaggerTag("Endpoints untuk mengelola data pengguna")]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(MyDbContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet] // This attribute should be applied to methods
        // [SwaggerOperation("Mendapatkan daftar pengguna", Tags = new[] { "Pengguna" })]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                _logger.LogInformation("Fetching users...");
                var users = _context.Users.ToList();
                return Ok(new GenericResponse(200, "SUCCESS", users));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching users.");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public IActionResult GetById([FromRoute] int id)
        {
            _logger.LogInformation("Fetching user...");
            var user = _context.Users.Find(id);

            if (user == null)
            {
                _logger.LogInformation("user not found.");
                return NotFound(new GenericResponse(404, "Data User tidak ditemukan"));
            }

            return Ok(new GenericResponse(200, "SUCCESS", user));
        }
    }
}
