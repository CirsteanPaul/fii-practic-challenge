using System;
using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectServices.Exceptions;
using hackatonBackend.ProjectServices.Mappers;
using hackatonBackend.ProjectServices.Services.Users;

namespace hackatonBackend.ProjectServices.Services.Jobs
{
	public class JobService : IJobService
	{
		private readonly IUnitOfWork unitOfWork;

		public JobService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public void CreateJob(CreateJobDto dto)
		{
			if (!dto.UserId.HasValue) {
				throw new AuthorizationException("You must be a company to do this action");
			}

			var user = unitOfWork.Users.GetUserById(dto.UserId.Value);

			if (user is null || !user.Role.HasValue || user.Role.Value != (short)Role.Company) {
                throw new AuthorizationException("You must be a company to do this action");
            }

			var job = dto.ToEntity();

			unitOfWork.Jobs.Add(job);
			unitOfWork.SaveChanges();
		}
	}
}

