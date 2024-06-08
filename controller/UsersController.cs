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

using Microsoft.AspNetCore.Mvc;
using MyAngularApp.models;
using MyAngularApp.Data;
using Swashbuckle.AspNetCore.Annotations;

namespace MyAngularApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Endpoints untuk mengelola data pengguna")]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet] // This attribute should be applied to methods
        [Route("")] // You can specify route here or in the controller level
        [SwaggerOperation("Mendapatkan daftar pengguna", Tags = new[] { "Pengguna" })]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }
}
