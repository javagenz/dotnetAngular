using Microsoft.AspNetCore.Mvc;
using MyAngularApp.models;
using MyAngularApp.Services;
using Swashbuckle.AspNetCore.Annotations;
using MyAngularApp.DTOs;

namespace MyAngularApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceDuaController : ControllerBase
    {
        private readonly IServiceDua _serviceDua;

        public ServiceDuaController(IServiceDua serviceDua)
        {
            _serviceDua = serviceDua;
        }

        [HttpGet]
       // [SwaggerOperation("Mendapatkan daftar profil", Tags = new[] { "Dua" })]
       // [ProducesResponseType(typeof(IEnumerable<Profil>), 200)]
        public async Task<ActionResult<IEnumerable<Profil>>> GetProfil()
        {
            var data = await _serviceDua.GetAllProfilesAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        //[SwaggerOperation("Mendapatkan profil berdasarkan ID", Tags = new[] { "Dua" })]
        //[ProducesResponseType(typeof(Profil), 200)]
        //[ProducesResponseType(404)]
        public async Task<ActionResult<Profil>> GetProfilById(int id)
        {
            var profile = await _serviceDua.GetProfilByIdAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpGet("byAge/{age}")]
        //[SwaggerOperation("Mendapatkan profil berdasarkan umur", Tags = new[] { "Dua" })]
        //[ProducesResponseType(typeof(IEnumerable<Profil>), 200)]
        public async Task<ActionResult<IEnumerable<Profil>>> GetProfilesByAge(int age)
        {
            var profiles = await _serviceDua.GetProfilesByAgeAsync(age);
            return Ok(profiles);
        }

        [HttpGet("withDetails/{id}")]
        //[SwaggerOperation("Mendapatkan profil beserta data terkait berdasarkan ID", Tags = new[] { "Dua" })]
        //[ProducesResponseType(typeof(Profil), 200)]
        //[ProducesResponseType(404)]
        public async Task<ActionResult<Profil>> GetProfilWithDetails(int id)
        {
            var profile = await _serviceDua.GetProfilWithDetailsAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }


        [HttpPost]
        public async Task<ActionResult<Profil>> PostProfil([FromBody] ProfilDto profilDto)
        {
            var profil = new Profil
            {
    
                username = profilDto.username,
                email = profilDto.email,
                alamat = profilDto.alamat,
                age = profilDto.age
              
            };

            var createdProfil = await _serviceDua.AddProfilAsync(profil);

            return CreatedAtAction(nameof(GetProfilById), new { id = createdProfil.id }, createdProfil);
        }

       
    }
}
