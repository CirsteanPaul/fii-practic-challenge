using System;
using hackatonBackend.ProjectServices.Mappers;
using hackatonBackend.ProjectServices.Services.Business;
using hackatonBackend.WebApi.Models.Companies;

namespace hackatonBackend.WebApi.Mappers
{
	public static class CompanyMapper
	{
		public static CompanyModel ToApiModel(this CompanyDto dto)
		{
            if (dto is null) {
                return null;
            }

            return new CompanyModel
            {
                Id = dto.Id,
                CreatedAt = dto.CreatedAt,
                Description = dto.Description,
                TypeOfCompany = dto.TypeOfCompany,
                Logo = dto.Logo,
                User = dto.User.ToApiUserModel(),
                UserId = dto.UserId
            };
		}
	}
}

