using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Context;
using hackatonBackend.ProjectData.Infrastructure.Repository;
using hackatonBackend.ProjectData.Repositories;
using Microsoft.EntityFrameworkCore;

namespace hackatonBackend.ProjectData.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        private readonly IAppDbContext dbContext;
        public JobRepository(IAppDbContext dbContext) : base ((DbContext)dbContext) 
        {
            this.dbContext = dbContext;
        }
        public Job GetJobById( int id) 
        { 
            return dbContext.Jobs
                .FirstOrDefault(j => j.Id == id);
        }
        public Job GetJobByName( string name ) 
        {
            return dbContext.Jobs
                .FirstOrDefault(j => j.Name == name);
        }
        public Job GetJobByCompanyId ( int companyId ) 
        {
            return dbContext.Jobs
                .FirstOrDefault(j => j.CompanyId == companyId);
        }
        public IEnumerable<Job> GetAllJobsByCompany(int companyId)
        {
            return dbContext.Jobs.Where(x => x.CompanyId == companyId);
        }
    }
}
