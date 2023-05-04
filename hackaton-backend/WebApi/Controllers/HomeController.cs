using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using hackatonBackend.ProjectServices.Services.Blob;
using hackatonBackend.WebApi.Models.Blob;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.WebApi.Controllers
{
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        private readonly IBlobService blobService;

        public HomeController(IBlobService blobService)
        {
            this.blobService = blobService;
        }

        // GET: /<controller>/
        [HttpGet("test")]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("blob")]
        public ActionResult<BlobImageDto> GetBlob() {
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
        public ActionResult UpdateBlob([FromBody] ImageRequest image)
        {
            blobService.UploadBlob(image.Name, null, image.ContainerName);

            return Ok();
        }
    }
}

