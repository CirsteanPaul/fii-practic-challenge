using System;
namespace hackatonBackend.ProjectData.Entities
{
	public sealed class Recruit
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public double? CodingScore { get; set; }
        public double? PsychologyScore { get; set; }
		public short? PersonalityType { get; set; }
		public double? TotalScore { get; set; }
		public int NumberOfFollowers { get; set; }
		public int NumberOfFollowings { get; set; }

		public User User { get; set; }
	}
}

