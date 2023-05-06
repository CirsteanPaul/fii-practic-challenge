using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Repository;

namespace hackatonBackend.ProjectData.Repositories
{
	public interface IRecruitRepository : IRepository<Recruit>
	{
		Recruit GetRecruitByUserId(int id);
		IEnumerable<Recruit> GetAllRecruits();
    }
}

