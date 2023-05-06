using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using hackatonBackend.ProjectData.Infrastructure.Context;
using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectData.Repositories;
using hackatonBackend.ProjectServices.Services.Blob;
using hackatonBackend.ProjectServices.Services.Questions;
using hackatonBackend.WebApi.Models.Blob;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.WebApi.Controllers
{
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        private readonly IBlobService blobService;
        private readonly IUnitOfWork unitofwork;

        public HomeController(IUnitOfWork unitofwork, IBlobService blobService, IAppDbContext appDbContext)
        {
            this.blobService = blobService;
            this.unitofwork = unitofwork;
        }

        // GET: /<controller>/
        [HttpGet("test")]
        public IActionResult Index()
        {
            var questions = unitofwork.Questions.GetAllQuestionWithParams(new QuestionMetrics());
            var games = unitofwork.Games.GetGame(1);
            return Ok();
        }

        [HttpGet("blob")]
        public ActionResult<FileModel> GetBlob() {
            var blobImage = blobService.GetBlob("pfphunters.jpeg");

            return blobImage;
        }

        [HttpDelete("blob")]
        public ActionResult DeleteBlob([FromBody] int id)
        {
            int x = id;
            var blobImage = blobService.DeleteBlob("pfphunters.jpeg", "hackaton-images");

            return Ok();
        }

        [HttpPut("blob/update")]
        public ActionResult UpdateBlob([FromForm] FileModel image)
        {
            blobService.UploadBlob(image.Name, image.File);

            return Ok();
        }

        //[HttpGet]
        //public ActionResult GetTest() {
        //    var jobs = appDbContext.Jobs.ToList();
        //    var applications = appDbContext.Applications.ToList();
        //    var companies = appDbContext.Companies.ToList();
        //    var recruits = appDbContext.Recruits.ToList();
        //    var cvs = appDbContext.Cvs.ToList();
        //    return Ok();
        //}
    }
}

