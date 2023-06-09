using Microsoft.EntityFrameworkCore;
using Streaming.DataAccess.Concrete.EntityFramework.Configuration.Mappings;
using Streaming.Entities.Concrete;

namespace Streaming.DataAccess.Concrete.EntityFramework.Configuration
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Movies> Movies { get; set; }

        public DbSet<Movies> Series { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Using existing DB from another project
            optionsBuilder.UseSqlServer(@"Server=(localdb)\TvShowTracker.Master;Database=TvShowTrackerDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new MoviesConfiguration());
            modelBuilder.ApplyConfiguration(new SeriesConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.Seed();
        }
    }
}
