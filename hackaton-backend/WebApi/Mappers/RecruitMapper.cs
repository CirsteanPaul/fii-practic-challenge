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
                User = dto.User.ToApiUserModel(),
                AgreeableScore = dto.AgreeableScore,
                CalmScore = dto.CalmScore,
                Gender = dto.Gender,
                AssertiveScore = dto.AssertiveScore,
                NumberOfFollowers = dto.NumberOfFollowers,
                NumberOfFollowings = dto.NumberOfFollowings,
                TotalScore = dto.TotalScore,
                PersonalityType = (PersonalityType?)dto.PersonalityType
            };
		}
public static RecruitDto ToDto(this RecruitModel model) 
        { 
            if (model is null)
            {
                return null;
            }
            return new RecruitDto
            {
                Id = model.Id,
                User = model.User.ToDto(),
                UserId = model.UserId,
                CalmScore = model.CalmScore,
                Gender = model.Gender,
                AssertiveScore = model.AssertiveScore,
                AgreeableScore = model.AgreeableScore,
                CodingScore = model.CalmScore,
                PsychologyScore = model.PsychologyScore,
                PersonalityType = (PersonalityType?)model.PersonalityType,
                TotalScore = model.TotalScore,
                NumberOfFollowers = model.NumberOfFollowers,
                NumberOfFollowings = model.NumberOfFollowings,
            };
        }
	}
}

