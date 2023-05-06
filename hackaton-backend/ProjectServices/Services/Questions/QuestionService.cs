using System;
using hackatonBackend.ProjectData;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectServices.Exceptions;

namespace hackatonBackend.ProjectServices.Services.Questions
{
	public class QuestionService : IQuestionService
	{

		private readonly IUnitOfWork unitOfWork;

		public QuestionService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public void RespondQuestion(int gameId, int questionId, int answer) {
			var game = unitOfWork.Games.GetGame(gameId);
            var question = unitOfWork.Questions.GetQuestionById(questionId);
			AddQuestionToGame(game, questionId);
            if(answer == 1) {
                game.CurrentCalmScore += question.Answer1CalmScore;
                game.CurrentAgreeableScore += question.Answer1AgreeableScore;
                game.CurrentAssertieScore += question.Answer1AssertiveScore;
                game.CurrentPshycologyScore += question.Answer1PsychologyScore;
            }

            if (answer == 2)
            {
                game.CurrentCalmScore += question.Answer2CalmScore;
                game.CurrentAgreeableScore += question.Answer2AgreeableScore;
                game.CurrentAssertieScore += question.Answer2AssertiveScore;
                game.CurrentPshycologyScore += question.Answer2PsychologyScore;
            }

            if (answer == 3)
            {
                game.CurrentCalmScore += question.Answer3CalmScore;
                game.CurrentAgreeableScore += question.Answer3AgreeableScore;
                game.CurrentAssertieScore += question.Answer3AssertiveScore;
                game.CurrentPshycologyScore += question.Answer3PsychologyScore;
            }

            unitOfWork.SaveChanges();
        }

        public Question GetNewQuestion(int gameId)
		{
			var game = unitOfWork.Games.GetGame(gameId);

			if (game is null) {
				throw new EntityNotFoundException(gameId, typeof(Game));
			}

			var questionMetrics = new QuestionMetrics()
			{
				MinimumAgreeableScore = game.CurrentAgreeableScore,
				MinimumAssertieScore = game.CurrentAssertieScore,
				MinimumPshycologyScore = game.CurrentPshycologyScore,
				MiniumCalmScore = game.CurrentCalmScore
			};

			var filteredQuestions = unitOfWork.Questions.GetAllQuestionWithParams(questionMetrics);

			var random = new Random();
			var randomIndex = random.Next(0, filteredQuestions.Count());

			return filteredQuestions.ToList()[randomIndex];
		}

		public IEnumerable<Question> GetHistoryQuestions(int gameId)
		{
            var game = unitOfWork.Games.GetGame(gameId);

            if (game is null)
            {
                throw new EntityNotFoundException(gameId, typeof(Game));
            }

			var gameQuestions = unitOfWork.Questions.GetAllQuestionsOfGame(game);

			if(gameQuestions is null) {
				return new List<Question>();
			}

			return gameQuestions;
        }

		public Game GetGameById(int gameId) {
            var game = unitOfWork.Games.GetGame(gameId);

			if (game is null) {
                throw new EntityNotFoundException(gameId, typeof(Game));
            }

			return game;
        }

		public Game GetLatestGameByUser(int? userId) {
            if (!userId.HasValue)
            {
                throw new BusinessException("User most pe logged in to perform a game");
            }

			return unitOfWork.Games.GetLatestGame(userId.Value);
        }

        public void CreateNewGame (int? userId) {
			if (!userId.HasValue) {
				throw new BusinessException("User most pe logged in to perform a game");
			}

			var newGame = new Game()
			{
				UserId = userId.Value,
				CurrentAgreeableScore = 0,
				CurrentAssertieScore = 0,
				CurrentCalmScore = 0,
				CurrentPshycologyScore = 0,
                CreatedAt = DateTime.Now
			};

			unitOfWork.Games.Add(newGame);
			unitOfWork.SaveChanges();
		}

		private void AddQuestionToGame(Game game, int requestId) {
			if (game.QuestionId1 == 0) {
				game.QuestionId1 = requestId;
				return;
			}

            if (game.QuestionId2 == 0)
            {
                game.QuestionId2 = requestId;
                return;
            }

            if (game.QuestionId3 == 0)
            {
                game.QuestionId3 = requestId;
                return;
            }

            if (game.QuestionId4 == 0)
            {
                game.QuestionId4 = requestId;
                return;
            }

            if (game.QuestionId5 == 0)
            {
                game.QuestionId5 = requestId;
                return;
            }

            if (game.QuestionId6 == 0)
            {
                game.QuestionId6 = requestId;
                return;
            }

            if (game.QuestionId7 == 0)
            {
                game.QuestionId7 = requestId;
                return;
            }

            if (game.QuestionId8 == 0)
            {
                game.QuestionId8 = requestId;
                return;
            }

            if (game.QuestionId9 == 0)
            {
                game.QuestionId9 = requestId;
                return;
            }
            if (game.QuestionId10 == 0)
            {
                game.QuestionId10 = requestId;
                return;
            }
        }

    }
}

