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
            IJobRepository jobRepository,
            ICompanyRepository companyRepository,
            IRecruitRepository recruitRepository,
            ICvRepository cvRepository)
        {
            this.context = context;
            this.Users = userRepository;
            this.Jobs = jobRepository;
            this.Cvs = cvRepository;
            this.Recruits = recruitRepository;  
        }

        #region Repositories
        public IUserRepository Users { get; private set; }
        public IJobRepository Jobs { get; private set; }
        public ICompanyRepository Companies{ get; private set; }
        public ICvRepository Cvs { get; private set; }
        public IRecruitRepository Recruits { get; private set; }

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
