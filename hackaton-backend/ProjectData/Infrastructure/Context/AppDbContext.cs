using hackatonBackend.ProjectData.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace hackatonBackend.ProjectData.Infrastructure.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Recruit> Recruits { get; set; }
        public DbSet<Cv> Cvs { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Applies entity model configurations from the Data Configuration namespace
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
