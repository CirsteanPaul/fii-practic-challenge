using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Repository;

namespace hackatonBackend.ProjectData.Repositories
{
    public interface ICvRepository : IRepository<Cv>
    {
        Cv GetCvByUserId(int userId);
        Cv GetCvById(int id);
    }
}
