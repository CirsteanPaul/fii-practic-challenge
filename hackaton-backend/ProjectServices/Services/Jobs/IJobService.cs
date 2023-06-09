﻿namespace hackatonBackend.ProjectServices.Services.Jobs
{
    public interface IJobService
    {
        void CreateJob(CreateJobDto dto);
        IEnumerable<JobDto> GetAllJobsOfCompany(int? companyId);
    }
}