using Microsoft.EntityFrameworkCore;
using MyAngularApp.Data;
using MyAngularApp.models;

namespace MyAngularApp.Query
{
    public class ProfilQuery
    {
        private readonly MyDbContext _context;

        public ProfilQuery(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Profil> GetProfilWithDetailsAsync(int id)
        {
            return await _context.Profil
                .Include(p => p.alamat) // Assuming Profil has a collection of Addresses
                .FirstOrDefaultAsync(p => p.id == id);
        }
    }
}
