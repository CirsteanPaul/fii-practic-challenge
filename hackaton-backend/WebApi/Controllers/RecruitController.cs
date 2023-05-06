using System;
using hackatonBackend.ProjectServices.Services.Recruits;
using hackatonBackend.WebApi.Mappers;
using hackatonBackend.WebApi.Models.RecruitModel;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.WebApi.Controllers
{
	public class GetRecruitRequest {
		public int? UserId { get; set; }
	}
	[Route("api/recruits")]
	public class RecruitController : ApplicationController
	{
		private readonly IRecruitServices recruitServices;

		public RecruitController(IRecruitServices recruitServices)
		{
			this.recruitServices = recruitServices;
		}
		
		[HttpGet]
		public ActionResult<RecruitModel> GetRecruitById([FromBody] GetRecruitRequest request) {
			var recruit = recruitServices.GetRecruitData(request.UserId);

			return Ok(recruit.ToApiModel());
		}

		[HttpGet("all")]
		public ActionResult<IEnumerable<RecruitModel>> GetRecruitsInOrder() {
			var recruits = recruitServices.GetAllRecruits();

			return Ok(recruits.Select(x => x.ToApiModel()).ToList());
		}
		[HttpPut("change")]
		public ActionResult ChangeRecruitDetails([FromBody] RecruitModel changes)
		{
			recruitServices.ChangeDetails( UserId , changes.ToDto());
			return Ok();
		}
	}
}

