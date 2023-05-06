using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectServices.Services;
using hackatonBackend.ProjectServices.Services.Recruits;

namespace hackatonBackend.ProjectServices.Mappers
{
	public static class RecruitMapper
	{
		public static RecruitDto ToDto(this Recruit entity)
		{
			if (entity is null) {
				return null;
			}

			return new RecruitDto
			{
				Id = entity.Id,
				UserId = entity.UserId,
				CodingScore = entity.CodingScore,
				PsychologyScore = entity.PsychologyScore,
				User = entity.User.ToDto(),
                AgreeableScore = entity.AgreeableScore,
                CalmScore = entity.CalmScore,
                AssertiveScore = entity.AssertiveScore,
				NumberOfFollowers = entity.NumberOfFollowers,
				NumberOfFollowings = entity.NumberOfFollowings,
				TotalScore = entity.TotalScore,
				PersonalityType = (PersonalityType?)entity.PersonalityType
			};
		}

        public static Recruit ToEntity(this RecruitDto dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new Recruit
            {
                Id = dto.Id,
                UserId = dto.UserId,
                CodingScore = dto.CodingScore,
                PsychologyScore = dto.PsychologyScore,
                User = dto.User.ToEntity(),
                AgreeableScore = dto.AgreeableScore,
                CalmScore = dto.CalmScore,
                AssertiveScore = dto.AssertiveScore,
                NumberOfFollowers = dto.NumberOfFollowers,
                NumberOfFollowings = dto.NumberOfFollowings,
                TotalScore = dto.TotalScore,
                PersonalityType = (short?)dto.PersonalityType
            };
        }
    }
}

