using System;
using hackatonBackend.ProjectServices.Services.Businesses;
using hackatonBackend.WebApi.Mappers;
using hackatonBackend.WebApi.Models.Companies;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.WebApi.Controllers
{
	public sealed class CompanyRequest
	{
		public int? UserId { get; set; }
	}

	[Route("api/company")]
	public class CompanyController : ApplicationController
	{
		private readonly ICompanyService companyService;

		public CompanyController(ICompanyService companyService)
		{
			this.companyService = companyService;
		}

		[HttpGet("info")]
		public ActionResult<CompanyModel> GetCompanyInformations([FromBody] CompanyRequest request) {
			var companyDetails = companyService.GetCompanyDetails(request.UserId);

			return Ok(companyDetails.ToApiModel());
		}
		[HttpPut("change")]
		public ActionResult ChangeCompanyDetails([FromBody] CompanyModel changes) 
		{ 
			companyService.ChangeDetails(UserId, changes.ToDto());
			return Ok();
		}
	}
}

