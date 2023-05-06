using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Repository;

namespace hackatonBackend.ProjectData.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Company GetCompanyById(int id);
        Company GetCompanyByName(string name);
    }
}
