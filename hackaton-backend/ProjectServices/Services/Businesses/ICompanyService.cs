using System;
using hackatonBackend.ProjectServices.Services.Business;

namespace hackatonBackend.ProjectServices.Services.Businesses
{
	public interface ICompanyService
	{
        CompanyDto GetCompanyDetails(int? userId);
        void ChangeDetails(int? userId, CompanyDto company);
    }
}

