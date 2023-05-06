using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Repository;

namespace hackatonBackend.ProjectData.Repositories
{
    public interface IJobRepository : IRepository<Job>
    {
        Job GetJobByCompanyId (int companyId);
        Job GetJobByName(string name);
        Job GetJobById (int id);
        IEnumerable<Job> GetAllJobsByCompany(int companyId);
    }
}
