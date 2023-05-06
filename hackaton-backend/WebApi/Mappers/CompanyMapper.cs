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
                Name = dto.Name,
                Logo = ImageMapper.AddPrefixToImage(dto.Logo),
                User = dto.User.ToApiUserModel(),
                UserId = dto.UserId
            };
		}
        public static CompanyDto ToDto(this CompanyModel model)
        {
            if (model is null)
            {
                return null;
            }
            return new CompanyDto
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                Description = model.Description,
                TypeOfCompany = model.TypeOfCompany,
                Name = model.Name,
                Logo = model.Logo,
                User = model.User.ToDto(),
                UserId = model.UserId
            };
        }
	}
}

