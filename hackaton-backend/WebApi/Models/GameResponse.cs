using System;
using hackatonBackend.ProjectData;
using hackatonBackend.ProjectData.Entities;

namespace hackatonBackend.WebApi.Models
{
	public sealed class GameResponse
	{
		public GameModel Game { get; set; }
		public IEnumerable<QuestionModel> HistoryQuestions { get; set; }
		public QuestionModel NewQuestion { get; set; }
	}
}

