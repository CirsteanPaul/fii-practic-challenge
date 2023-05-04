using System;
using System.ComponentModel.DataAnnotations;

namespace hackatonBackend.WebApi.Models.Blob
{
    public class ImageRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public string ContainerName { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}

