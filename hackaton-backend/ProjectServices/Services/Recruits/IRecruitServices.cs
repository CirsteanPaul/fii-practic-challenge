﻿using System;
namespace hackatonBackend.ProjectServices.Services.Recruits
{
	public interface IRecruitServices
	{
		RecruitDto GetRecruitData(int? userId);
		IEnumerable<RecruitDto> GetAllRecruits();
		void ChangeDetails(int? userId, RecruitDto recruitDto);
    }
}
