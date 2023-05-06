using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectServices.Exceptions;
using hackatonBackend.ProjectServices.Mappers;
using hackatonBackend.ProjectServices.Services.Common.Auth;

namespace hackatonBackend.ProjectServices.Services.Recruits
{
	public class RecruitServices : IRecruitServices
	{
		private readonly IUnitOfWork unitOfWork;

		public RecruitServices(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public RecruitDto GetRecruitData (int? userId) {
			if (!userId.HasValue) {
				throw new BusinessException("No user id provided");
			}

			var recruit = unitOfWork.Recruits.GetRecruitByUserId(userId.Value);

			if(recruit is null) {
				throw new EntityNotFoundException(userId.Value, typeof(Recruit));
			}

			var recruitDto = recruit.ToDto();

			return recruitDto;
		}

        public IEnumerable<RecruitDto> GetAllRecruits()
		{
			var recruits = unitOfWork.Recruits.GetAllRecruits();

			return recruits.Select(r => r.ToDto()).ToList();
		}
		public void ChangeDetails(int? id, RecruitDto recruitDto) 
		{
            if (!id.HasValue)
            {
                throw new AuthorizationException("You're not logged in");
            }
            if (recruitDto is null)
            {
                return;
            }
			var recruit = unitOfWork.Recruits.GetRecruitByUserId (id.Value);
            if (recruit.UserId != id.Value)
            {
                throw new AuthorizationException("You're not allowed to change this Account");
            }
            if (recruitDto.CodingScore is not null)
			{
				recruit.CodingScore = recruitDto.CodingScore;
			}
			if (recruitDto.PsychologyScore is not null) 
			{ 
			recruitDto.PsychologyScore = recruitDto.PsychologyScore;
			}
			if(recruitDto.CalmScore is not null)
			{
				recruitDto.CalmScore = recruitDto.CalmScore;
			}
			if(recruitDto.AssertiveScore is not null) 
			{ 
				recruitDto.AssertiveScore = recruitDto.AssertiveScore;
			}
			if(recruitDto.AgreeableScore is not null)
			{
				recruitDto.AgreeableScore = recruitDto.AgreeableScore;
			}
			if(recruitDto.TotalScore is not null) 
			{
			 recruitDto.TotalScore = recruitDto.TotalScore;
			}
			if(recruitDto.PersonalityType is not null)
			{
				recruit.PersonalityType = (short)recruitDto.PersonalityType;
			}
			if(recruitDto.Gender is not null)
			{
				recruit.Gender = (short)recruitDto.Gender;	
			}
            unitOfWork.Recruits.Update(recruit);
            unitOfWork.SaveChanges();

        }

    }
}

