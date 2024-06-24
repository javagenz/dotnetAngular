using MyAngularApp.Data;
using MyAngularApp.models;

namespace MyAngularApp.Services
{
    public interface IProfilService
    {
        Profil GetProfilById(int id);
        IEnumerable<Profil> GetAllProfiles();
    }

    public class ProfilService : IProfilService
    {
        private readonly MyDbContext _context;

        public ProfilService(MyDbContext context)
        {
            _context = context;
        }

        public Profil GetProfilById(int id)
        {
            return _context.Profil.FirstOrDefault(p => p.id == id);
        }

        public IEnumerable<Profil> GetAllProfiles()
        {
            return _context.Profil.ToList();
        }

        public Profil GetProfilByid(int id)
        {
            throw new NotImplementedException();
        }
    }
}