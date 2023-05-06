using System;
using hackatonBackend.ProjectData.Entities;

namespace hackatonBackend.ProjectData
{
	public sealed class Game
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int QuestionId1 { get; set; }
		public int QuestionId2 { get; set; }
		public int QuestionId3 { get; set; }
		public int QuestionId4 { get; set; }
		public int QuestionId5 { get; set; }
		public int QuestionId6 { get; set; }
		public int QuestionId7 { get; set; }
		public int QuestionId8 { get; set; }
		public int QuestionId9 { get; set; }
		public int QuestionId10 { get; set; }
		public DateTime? CreatedAt { get; set; }

		public double? CurrentCalmScore { get; set; }
		public double? CurrentAgreeableScore { get; set; }
		public double? CurrentAssertieScore { get; set; }
		public double? CurrentPshycologyScore { get; set; }

	}
}

