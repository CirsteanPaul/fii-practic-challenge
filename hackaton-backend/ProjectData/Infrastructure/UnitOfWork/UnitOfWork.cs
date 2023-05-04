using hackatonBackend.ProjectData.Infrastructure.Context;
using hackatonBackend.ProjectData.Repositories;
using HackBackend.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace hackatonBackend.ProjectData.Infrastructure.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IAppDbContext context;

        public UnitOfWork(
             IAppDbContext context,
            IUserRepository userRepository,
            IToDoRepository toDoRepository)
        {
            this.context = context;
            this.Users = userRepository;
            this.ToDos = toDoRepository;
        }

        #region Repositories
        public IUserRepository Users { get; private set; }
        public IToDoRepository ToDos { get; private set; }
        #endregion

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return context.SaveChangesAsync(cancellationToken);
        }

        public void Reload<TEntity>(TEntity entity) where TEntity : class
        {
            context.Entry(entity).Reload();
        }

        public bool IsModified<TEntity>(TEntity entity) where TEntity : class
        {
            return context.Entry(entity).State == EntityState.Modified;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
