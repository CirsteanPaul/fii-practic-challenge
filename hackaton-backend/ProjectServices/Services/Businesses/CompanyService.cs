using System;
using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectServices.Exceptions;
using hackatonBackend.ProjectServices.Mappers;
using hackatonBackend.ProjectServices.Services.Business;

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
	}
}

