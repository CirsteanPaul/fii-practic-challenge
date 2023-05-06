using System;
using hackatonBackend.ProjectData;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.WebApi.Models;

namespace hackatonBackend.WebApi.Mappers
{
	public static class QuestionMapper
	{
		public static GameResponse ToModel(Game game, IEnumerable<Question> questions, Question newQuestion) {
			return new GameResponse
			{
				Game = game.ToModel(),
				HistoryQuestions = questions.Select(x => x.ToModel()).ToList(),
				NewQuestion = newQuestion.ToModel()
			};
		}

		public static QuestionModel ToModel(this Question question) {
			return new QuestionModel
			{
				Id = question.Id,
				Answer1 = question.Answer1,
				Answer2 = question.Answer2,
				Answer3 = question.Answer3,
				Question = question.QuestionSentence,
			};
		}

        public static GameModel ToModel(this Game game)
        {
            return new GameModel
            {
                Id = game.Id,
                UserId = game.UserId,
            };
        }
    }
}

