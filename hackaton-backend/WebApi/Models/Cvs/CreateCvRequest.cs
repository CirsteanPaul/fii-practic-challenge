using System.ComponentModel.DataAnnotations;

namespace hackatonBackend.WebApi.Models.Cvs
{
    public class CreateCvRequest
    {
        [Required]
        public string GeneralSkills { get; set; }
        [Required]
        public string ExtracurricularActivities { get; set; }
        [Required]
        public string Experience { get; set; }
    }
}
