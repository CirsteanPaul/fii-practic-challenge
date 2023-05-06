using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace hackatonBackend.ProjectData.Infrastructure.Context
{
    public interface IAppDbContext : IEntityFrameworkContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Application> Applications { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Job> Jobs { get; set; }
        DbSet<Recruit> Recruits { get; set; }
        DbSet<Cv> Cvs { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Game> Games { get; set; }
    }
}
