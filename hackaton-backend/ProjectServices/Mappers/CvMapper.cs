using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectServices.Services.Common.Auth;
using hackatonBackend.ProjectServices.Services.Cvs;
using hackatonBackend.ProjectServices.Services.Cvs;

namespace hackatonBackend.ProjectServices.Mappers
{
    public static class CvMapper
    {
        public static CvDto ToDto(this Cv entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new CvDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                GeneralSkills   = entity.GeneralSkills,
                Experience = entity.Experience,
                ExtracurricularActivities = entity.ExtracurricularActivities,
            };
        }
        public static Cv ToEntity(this CreateCvDto cvDto, int? UserId) 
        {
            return new Cv
            {
                UserId = UserId.Value,
                Experience = cvDto.Experience,
                GeneralSkills = cvDto.GeneralSkills,
                ExtracurricularActivities = cvDto.ExtracurricularActivities,
            };
        }
    }
}
