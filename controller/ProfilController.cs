using Microsoft.AspNetCore.Mvc;
using MyAngularApp.models;
using MyAngularApp.Services; // Pastikan namespace diimpor dengan benar
using Swashbuckle.AspNetCore.Annotations;

namespace MyAngularApp.Controllers
{
    [ApiController]
    [Route("profile/[controller]")]
    public class ProfilController : ControllerBase
    {
        private readonly IProfilService _profilService;

        public ProfilController(IProfilService profilService)
        {
            _profilService = profilService;
        }

        

        [HttpGet]
        [Route("mypro")]
       // [SwaggerOperation("Mendapatkan daftar profil", Tags = new[] { "test" })]
        //[ProducesResponseType(typeof(IEnumerable<Profil>), 200)]
        public ActionResult<IEnumerable<Profil>> GetProfil()
        {
            var data = _profilService.GetAllProfiles();
            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        //[SwaggerOperation("Mendapatkan profil berdasarkan ID")]
        //[ProducesResponseType(typeof(Profil), 200)]
        //[ProducesResponseType(404)]
        public ActionResult<Profil> GetProfilById(int id)
        {
            var profil = _profilService.GetProfilById(id);
            if (profil == null)
            {
                return NotFound();
            }
            return Ok(profil);
        }

    }
}
