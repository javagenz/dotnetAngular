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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dotnet");
            base.OnModelCreating(modelBuilder);
        }
    }
}
