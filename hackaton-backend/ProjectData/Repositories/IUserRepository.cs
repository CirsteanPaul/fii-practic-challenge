using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Repository;

namespace hackatonBackend.ProjectData.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        User GetUserById(int id);
    }
}
