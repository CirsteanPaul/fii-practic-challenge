using System;
namespace hackatonBackend.ProjectData.Entities
{
	public class Question
	{
		public int Id { get; set; }
		public string QuestionSentence { get; set; }
        public string Answer1 { get; set; }
		public string Answer2 { get; set; }
		public string Answer3 { get; set; }
		public double? Answer1AssertiveScore { get; set; }
		public double? Answer1CalmScore { get; set; }
		public double? Answer1PsychologyScore { get; set; }
		public double? Answer1AgreeableScore { get; set; }
        public double? Answer2AssertiveScore { get; set; }
        public double? Answer2CalmScore { get; set; }
        public double? Answer2PsychologyScore { get; set; }
        public double? Answer2AgreeableScore { get; set; }
        public double? Answer3AssertiveScore { get; set; }
        public double? Answer3CalmScore { get; set; }
        public double? Answer3PsychologyScore { get; set; }
        public double? Answer3AgreeableScore { get; set; }

        public double? MinimumAgreeableScore { get; set; }
        public double? MinimumAssertieScore { get; set; }
        public double? MiniumCalmScore { get; set; }
        public double? MinimumPshycologyScore { get; set; }
    }
}

