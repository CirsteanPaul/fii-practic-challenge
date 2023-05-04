using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace hackatonBackend.ProjectData.Infrastructure.Context
{
    public interface IAppDbContext : IEntityFrameworkContext
    {
        DbSet<User> Users { get; set; }
        DbSet<ToDo> ToDos { get; set; }
    }
}
