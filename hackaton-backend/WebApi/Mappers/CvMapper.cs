using hackatonBackend.ProjectServices.Services.Cvs;
using hackatonBackend.WebApi.Models.Cvs;

namespace hackatonBackend.WebApi.Mappers
{
    public static class CvMapper
    {
        public static CvModel ToApiModel(this CvDto cvDto) 
        {
        if(cvDto is null)
            { 
                return null;
            }
            return new CvModel
            {
                Id = cvDto.Id,
                UserId = cvDto.UserId,
                GeneralSkills = cvDto.GeneralSkills,
                Experience = cvDto.Experience,
                ExtracurricularActivities = cvDto.ExtracurricularActivities,
            };
        }
        public static CreateCvDto ToDto(this CreateCvRequest model) 
        {
            if (model is null)
            {
                return null;
            }
            return new CreateCvDto
            {
                Experience = model.Experience,
                ExtracurricularActivities = model.ExtracurricularActivities,
                GeneralSkills = model.GeneralSkills,
            };
        }
    }
}
