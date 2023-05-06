using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Context;
using hackatonBackend.ProjectData.Infrastructure.Repository;
using hackatonBackend.ProjectData.Repositories;
using Microsoft.EntityFrameworkCore;

namespace hackatonBackend.ProjectData.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly IAppDbContext dbContext;
        public CompanyRepository(IAppDbContext dbContext) : base((DbContext)dbContext)
        {
            this.dbContext = dbContext;
        }
        public Company GetCompanyById(int id) 
        { 
            return dbContext.Companies
                .FirstOrDefault(c => c.Id == id);
        }
        public Company GetCompanyByName(string name)
        {
            return dbContext.Companies
                .FirstOrDefault(c => c.Name == name);
        }
    }
}
