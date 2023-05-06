using System;
using hackatonBackend.ProjectData.Entities;

namespace hackatonBackend.ProjectData.Repositories
{
	public interface IRecruitRepository
	{
		Recruit GetRecruitByUserId(int id);
    }
}

