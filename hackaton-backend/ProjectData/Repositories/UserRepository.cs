using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Context;
using hackatonBackend.ProjectData.Infrastructure.Repository;
using hackatonBackend.ProjectData.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HackBackend.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IAppDbContext dbContext;

        public UserRepository(IAppDbContext dbContext) : base((DbContext)dbContext)
        {
            this.dbContext = dbContext;
        }

        public User GetUserByUsername(string username)
        {
            return dbContext.Users
                .FirstOrDefault(u => u.Username == username);
        }

        public User GetUserById(int id)
        {
            return dbContext.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
