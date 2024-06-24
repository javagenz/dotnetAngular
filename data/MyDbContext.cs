// using Microsoft.EntityFrameworkCore;
// using MyAngularApp.models;

// namespace MyAngularApp.Data
// {
//     public class MyDbContext : DbContext
//     {
//         public MyDbContext(DbContextOptions<MyDbContext> options)
//             : base(options)
//         {
//         }

//         public DbSet<MyEntity> MyEntities { get; set; }

//         public DbSet<User> Users { get; set; }

//         public DbSet<Databaru> Databaru { get; set; }

//         public DbSet<Profil> Profil { get ; set;}

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             modelBuilder.HasDefaultSchema("dotnet");
//             base.OnModelCreating(modelBuilder);
//         }
//     }
// }


using Microsoft.EntityFrameworkCore;
using MyAngularApp.models;

namespace MyAngularApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Databaru> Databaru { get; set; }
        public DbSet<Profil> Profil { get; set; } // Pastikan Profil ditambahkan ke dalam MyDbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dotnet");
            base.OnModelCreating(modelBuilder);
        }
    }
}

