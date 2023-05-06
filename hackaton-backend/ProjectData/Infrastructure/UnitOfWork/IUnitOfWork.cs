using System.Threading;
using System.Threading.Tasks;
using hackatonBackend.ProjectData.Repositories;
using HackBackend.Data.Repositories;

namespace hackatonBackend.ProjectData.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public IRecruitRepository Recruits { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void Reload<TEntity>(TEntity entity) where TEntity : class;
        bool IsModified<TEntity>(TEntity entity) where TEntity : class;
    }
}
