using hackatonBackend.ProjectServices.Services.Cvs;
using hackatonBackend.ProjectServices.Services.Recruits;
using hackatonBackend.WebApi.Controllers;
using hackatonBackend.WebApi.Mappers;
using hackatonBackend.WebApi.Models.Cvs;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.WebApi.Controllers
{
    public class GetCvRequest
    {
        public int? UserId { get; set; }
    }

    [Route("api/cv")]
    public class CvController : ApplicationController
    {
        private readonly ICvService cvServices;

        public CvController(ICvService cvService)
        {
            this.cvServices = cvService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public ActionResult<CvModel> GetCvByUserId([FromBody] GetCvRequest cvRequest)
        {
            var cv = cvServices.GetCvDetails(cvRequest.UserId);
            return Ok(cv.ToApiModel());
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public ActionResult CreateCv([FromBody] CreateCvRequest createCvRequest)
        {
            var createCvDto = createCvRequest.ToDto();
            cvServices.CreateCv(createCvDto, UserId);
            return StatusCode(201);
        }
    }
}
