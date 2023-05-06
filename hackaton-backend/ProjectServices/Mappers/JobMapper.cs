using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectServices.Services.Jobs;

namespace hackatonBackend.ProjectServices.Mappers
{
	public static class JobMapper
	{
		public static Job ToEntity(this JobDto dto)
		{
			if (dto is null) {
				return null;
			}

			return new Job
			{
				Name = dto.Name,
				Description = dto.Description
			};
		}

        public static Job ToEntity(this CreateJobDto dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new Job
            {
                CompanyId = dto.UserId.Value,
                Name = dto.Name,
                Description = dto.Description
            };
        }
    }
}

