using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Context;
using hackatonBackend.ProjectData.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace hackatonBackend.ProjectData.Repositories
{
	public class RecruitRepository : Repository<Recruit>, IRecruitRepository
	{
		private readonly IAppDbContext dbContext;

		public RecruitRepository(IAppDbContext dbContext) : base((DbContext)dbContext)
		{
			this.dbContext = dbContext;
		}

		public Recruit GetRecruitByUserId(int id)
		{
			return dbContext.Recruits
				.Include(x => x.User)
				.FirstOrDefault(x => x.UserId == id);
		}

		public IEnumerable<Recruit> GetAllRecruits()
		{
			return dbContext.Recruits
				.Include(r => r.User)
				.OrderByDescending(r => r.TotalScore)
				.Take(10)
				.ToList();
		}
	}
}

