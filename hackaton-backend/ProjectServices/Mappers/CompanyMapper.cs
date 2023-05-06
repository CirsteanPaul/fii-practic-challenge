using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectServices.Services.Business;
using hackatonBackend.ProjectServices.Services.Busniess;

namespace hackatonBackend.ProjectServices.Mappers
{
	public static class CompanyMapper
	{
		public static CompanyDto ToDto(this Company entity)
		{
			if (entity is null) {
				return null;
			}

			return new CompanyDto
			{
				Id = entity.Id,
				CreatedAt = entity.CreatedAt,
				Description = entity.Description,
				TypeOfCompany = (CompanyType?)entity.TypeOfCompany,
				Logo = entity.Logo,
				User = entity.User.ToDto(),
				UserId = entity.UserId,
                Name = entity.Name
			};
		}

        public static Company ToEntity(this CompanyDto dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new Company
            {
                Id = dto.Id,
                CreatedAt = dto.CreatedAt,
                Description = dto.Description,
                TypeOfCompany = (short?)dto.TypeOfCompany,
                Logo = dto.Logo,
                Name = dto.Name,
                User = dto.User.ToEntity(),
                UserId = dto.UserId
            };
        }
    }

}

