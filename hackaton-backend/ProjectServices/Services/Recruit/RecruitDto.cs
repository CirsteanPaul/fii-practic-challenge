using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectServices.Services.Recruit;

namespace hackatonBackend.ProjectServices.Services
{
	public sealed class RecruitDto
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public double? CodingScore { get; set; }
        public double? PsychologyScore { get; set; }
        public PersonalityType? PersonalityType { get; set; }
        public int TotalScore { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }

        public User User { get; set; }
    }
}

