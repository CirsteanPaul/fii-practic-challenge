using System;
using hackatonBackend.ProjectServices.Services.Jobs;
using hackatonBackend.WebApi.Models.Jobs;

namespace hackatonBackend.WebApi.Mappers
{
	public static class JobMapper
	{
		public static CreateJobDto ToCreateJobDto(CreateJobsModel model, int? userId) {
			if (model is null) {
				return new CreateJobDto
				{
					UserId = userId
				};
			}

			return new CreateJobDto
			{
				UserId = userId,
				Description = model.Description,
				Name = model.Name,
			};
		}

        public static JobModel ToJobModel(this JobDto dto)
        {
            if (dto is null)
            {
				return null;
            }

            return new JobModel
            {
                Id = dto.Id,
                Description = dto.Description,
                Name = dto.Name,
            };
        }
    }
}

