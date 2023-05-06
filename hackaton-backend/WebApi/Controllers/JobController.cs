using System;
using hackatonBackend.ProjectServices.Services.Jobs;
using hackatonBackend.ProjectServices.Services.Users;
using hackatonBackend.WebApi.Mappers;
using hackatonBackend.WebApi.Models;
using hackatonBackend.WebApi.Models.Jobs;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.WebApi.Controllers
{
    public class GetJobsCompanyRequest {
        public int? CompanyId { get; set; }
    }
    [Route("/api/jobs")]
    public class JobController : ApplicationController
    {
        private readonly IJobService jobService;

        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public ActionResult<UserDetailsModel> CreateNewJob([FromBody] CreateJobsModel request)
        {
            var requestDto = JobMapper.ToCreateJobDto(request, UserId);
            jobService.CreateJob(requestDto);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("company")]
        public ActionResult<IEnumerable<JobModel>> GetAllJobsOfCompany([FromBody] GetJobsCompanyRequest request)
        {
            var jobs = jobService.GetAllJobsOfCompany(request.CompanyId);

            return jobs.Select(j => j.ToJobModel()).ToList();
        }
    }
}
