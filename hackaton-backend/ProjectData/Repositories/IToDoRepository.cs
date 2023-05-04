using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Repository;

namespace hackatonBackend.ProjectData.Repositories
{
    public interface IToDoRepository : IRepository<ToDo>
    {
    ToDo GetToDoByTitle (string todoTitle);
    }
}
