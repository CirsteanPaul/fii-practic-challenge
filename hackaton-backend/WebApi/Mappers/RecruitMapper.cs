using System;
using hackatonBackend.ProjectServices.Services;
using hackatonBackend.ProjectServices.Services.Recruits;
using hackatonBackend.WebApi.Models.RecruitModel;

namespace hackatonBackend.WebApi.Mappers
{
	public static class RecruitMapper
	{
		public static RecruitModel ToApiModel(this RecruitDto dto)
		{
			if (dto is null) {
				return null;
			}

			return new RecruitModel
			{
                Id = dto.Id,
                UserId = dto.UserId,
                CodingScore = dto.CodingScore,
                PsychologyScore = dto.PsychologyScore,
                User = dto.User.ToApiModel(),
                AgreeableScore = dto.AgreeableScore,
                CalmScore = dto.CalmScore,
                AssertiveScore = dto.AssertiveScore,
                NumberOfFollowers = dto.NumberOfFollowers,
                NumberOfFollowings = dto.NumberOfFollowings,
                TotalScore = dto.TotalScore,
                PersonalityType = (PersonalityType?)dto.PersonalityType
            };
		}
	}
}

