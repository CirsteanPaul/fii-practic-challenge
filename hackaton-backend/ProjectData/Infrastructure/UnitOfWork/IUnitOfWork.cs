using System.Threading;
using System.Threading.Tasks;
using hackatonBackend.ProjectData.Repositories;
using HackBackend.Data.Repositories;

namespace hackatonBackend.ProjectData.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public IJobRepository Jobs { get; }
        public ICompanyRepository Companies { get; }
        public ICvRepository Cvs { get; }
        public IRecruitRepository Recruits { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void Reload<TEntity>(TEntity entity) where TEntity : class;
        bool IsModified<TEntity>(TEntity entity) where TEntity : class;
    }
}
