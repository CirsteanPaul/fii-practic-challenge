using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectServices.Exceptions;
using hackatonBackend.ProjectServices.Mappers;
using hackatonBackend.ProjectServices.Services.Business;
using hackatonBackend.ProjectServices.Services.Common.Auth;
using Microsoft.IdentityModel.Tokens;

namespace hackatonBackend.ProjectServices.Services.Businesses
{
	public class CompanyService : ICompanyService
	{
		private readonly IUnitOfWork unitOfWork;

		public CompanyService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public CompanyDto GetCompanyDetails(int? userId)
		{
			if (!userId.HasValue) {
				throw new BusinessException("You must be logged in as a company");
			}

			var company = unitOfWork.Companies.GetCompanyByUserId(userId.Value);

			if (company is null) {
				throw new BusinessException("There is no company for user");
			}

			return company.ToDto();
		}
		public void ChangeDetails(int? id, CompanyDto companyDto)
		{
            if (!id.HasValue)
            {
                throw new AuthorizationException("You're not logged in");
            }

            if (companyDto is null)
            {
                return;
            }
			var company = unitOfWork.Companies.GetCompanyByUserId(id.Value);

			if(company.UserId != id.Value) 
			{
                throw new AuthorizationException("You're not allowed to change this Company");
            }
			if(!string.IsNullOrEmpty(companyDto.Name)) 
			{ 
			company.Name = companyDto.Name;
			}
            if (!string.IsNullOrEmpty(companyDto.Description)) 
			{
			company.Description = companyDto.Description;
			}
            if (!string.IsNullOrEmpty(companyDto.Logo)) 
			{
			company.Logo = companyDto.Logo;
			}
			if(companyDto.TypeOfCompany is not null)
			{
			company.TypeOfCompany = (short)companyDto.TypeOfCompany;
			}
            unitOfWork.Companies.Update(company);
            unitOfWork.SaveChanges();
        }
	}
}

