using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectServices.Constants;
using hackatonBackend.ProjectServices.Services.Common.Auth;
using hackatonBackend.ProjectServices.Services.Recruits;

namespace hackatonBackend.ProjectServices.Services
{
	public sealed class RecruitDto
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public double? CodingScore { get; set; }
        public double? PsychologyScore { get; set; }
        public PersonalityType? PersonalityType { get; set; }
        public Gender? Gender { get; set; }
        public double? CalmScore { get; set; }
        public double? AssertiveScore { get; set; }
        public double? AgreeableScore { get; set; }
        public double? TotalScore { get; set; }
        public int NumberOfFollowers { get; set; }
        public int NumberOfFollowings { get; set; }

        public UserDto User { get; set; }
    }
}

