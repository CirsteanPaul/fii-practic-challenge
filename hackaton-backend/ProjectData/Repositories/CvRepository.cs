using hackatonBackend.ProjectData.Infrastructure.Repository;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Context;
using hackatonBackend.ProjectData.Repositories;
using Microsoft.EntityFrameworkCore;
namespace hackatonBackend.ProjectData.Repositories
{
    public class CvRepository : Repository<Cv>, ICVRepository
    {
        private readonly IAppDbContext dbContext;
        public CvRepository(IAppDbContext dbContext): base((DbContext)dbContext)
        { 
            this.dbContext = dbContext;
        }
        public Cv GetCvById(int id)
        {
             return dbContext.Cvs
                .FirstOrDefault(c => c.Id == id);
        }
     public Cv GetCvByUserId(int userId) {
        return dbContext.Cvs
                .FirstOrDefault (c => c.UserId == userId);
        }
    }
}
