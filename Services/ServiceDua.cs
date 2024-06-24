using Microsoft.EntityFrameworkCore;
using MyAngularApp.Data;
using MyAngularApp.models;
using MyAngularApp.Query;

namespace MyAngularApp.Services
{
    public interface IServiceDua
    {
        Task<Profil> GetProfilByIdAsync(int id);
        Task<IEnumerable<Profil>> GetAllProfilesAsync();
        Task<IEnumerable<Profil>> GetProfilesByAgeAsync(int age);
        Task<Profil> GetProfilWithDetailsAsync(int id);
        Task<Profil> AddProfilAsync(Profil profil); 
    }

    public class ServiceDua : IServiceDua
    {
        private readonly MyDbContext _context;
        private readonly ProfilQuery _profilQuery;

        public ServiceDua(MyDbContext context, ProfilQuery profilQuery)
        {
            _context = context;
            _profilQuery = profilQuery;
        }

        public async Task<Profil> GetProfilByIdAsync(int id)
        {
            return await _context.Profil.FindAsync(id);
        }

        public async Task<IEnumerable<Profil>> GetAllProfilesAsync()
        {
            return await _context.Profil.ToListAsync();
        }

        public async Task<IEnumerable<Profil>> GetProfilesByAgeAsync(int age)
        {
            return await _context.Profil
                .Where(p => p.age > age) // Periksa bahwa properti Age sesuai
                .ToListAsync();
        }

        public async Task<Profil> GetProfilWithDetailsAsync(int id)
        {
            return await _profilQuery.GetProfilWithDetailsAsync(id);
        }

        public async Task<Profil> AddProfilAsync(Profil profil)
        {
            _context.Profil.Add(profil);
            await _context.SaveChangesAsync();
            return profil;
        }
    }
}
