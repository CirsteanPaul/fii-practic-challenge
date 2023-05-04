using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Context;
using hackatonBackend.ProjectData.Infrastructure.Repository;
using hackatonBackend.ProjectData.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HackBackend.Data.Repositories
{
    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        private readonly IAppDbContext dbContext;

        public ToDoRepository(IAppDbContext dbContext) : base((DbContext)dbContext)
        {
            this.dbContext = dbContext;
        }

        public ToDo GetToDoByTitle(string todotitle)
        {
            return dbContext.ToDos
                .FirstOrDefault(u => u.Title == todotitle);
        }
    }
}
