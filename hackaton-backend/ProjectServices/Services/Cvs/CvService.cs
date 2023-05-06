using System;
using System.ComponentModel.DataAnnotations;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectServices.Constants;
using hackatonBackend.ProjectServices.Exceptions;
using hackatonBackend.ProjectServices.Mappers;
using hackatonBackend.ProjectServices.Services.Common.Auth;

namespace hackatonBackend.ProjectServices.Services.Cvs
{
    public class CvService : ICvService
    {
        private readonly IUnitOfWork unitOfWork;
        public CvService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void CreateCv(CreateCvDto cvDto, int? userId)
        {
            if (!userId.HasValue)
            {
                throw new AuthorizationException("You're not logged in");
            }

            var cvEntity = cvDto.ToEntity();
        }
        public CvDto GetCvDetais(int? id)
        {
            var cv = unitOfWork.Cvs.GetCvById(id.Value);
            if (cv is null) 
            { 
                throw new EntityNotFoundException(id.Value, typeof(Cv));
            }
            return cv.ToDto();
        }
        public void ChangeDetails(int? id, CvDto cvDto) 
        { 
            if(cvDto is null)
            {
                return;
            }
            var cv = unitOfWork.Cvs.GetCvById(id.Value);
            if(!string.IsNullOrEmpty(cvDto.ExtracurricularActivities)) 
            {
            cv.ExtracurricularActivities = cvDto.ExtracurricularActivities;
            }
            if(!string.IsNullOrEmpty(cvDto.Experience)) 
            { 
            cv.Experience = cvDto.Experience;
            }
            if(!string.IsNullOrEmpty(cvDto.GeneralSkills)) 
            {
            cv.GeneralSkills = cvDto.GeneralSkills;
            }
            unitOfWork.Cvs.Update(cv);
           unitOfWork.SaveChanges();
        }

      
       
    }
}
