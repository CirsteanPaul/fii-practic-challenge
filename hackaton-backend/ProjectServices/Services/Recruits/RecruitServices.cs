using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectServices.Exceptions;
using hackatonBackend.ProjectServices.Mappers;

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
	}
}

