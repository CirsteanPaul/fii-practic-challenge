﻿using System;
using hackatonBackend.ProjectData;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.UnitOfWork;
using hackatonBackend.ProjectServices.Exceptions;
using hackatonBackend.ProjectServices.Services.Recruits;


namespace hackatonBackend.ProjectServices.Services.Questions
{
	public class QuestionService : IQuestionService
	{

		private readonly IUnitOfWork unitOfWork;
        private readonly IRecruitServices recruitService;

		public QuestionService(IUnitOfWork unitOfWork, IRecruitServices recruitService)
		{
			this.unitOfWork = unitOfWork;
            this.recruitService = recruitService;
		}

		public void RespondQuestion(int gameId, int questionId, int answer) {
			var game = unitOfWork.Games.GetGame(gameId);

            if(game.QuestionId10 != 0) {
                throw new BusinessException("Game is already finished");
            }

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

            // game is over add data
            if(game.QuestionId10 != 0) {
                var newStats = CreateNewStatus(game);
                recruitService.ChangeDetails(game.UserId, newStats);
                return;
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

        private RecruitDto CreateNewStatus(Game game) {
            var newStats = new RecruitDto
            {
                PsychologyScore = game.CurrentPshycologyScore,
                CalmScore = game.CurrentCalmScore,
                AgreeableScore = game.CurrentAgreeableScore,
                AssertiveScore = game.CurrentAssertieScore,

            };

            var newTotalScore = (newStats.PsychologyScore.Value + newStats.CalmScore.Value
                + newStats.AssertiveScore.Value + newStats.AgreeableScore.Value) / 5;

            newStats.TotalScore = newTotalScore;

            if (newStats.PsychologyScore >= 50) {
                newStats.PersonalityType = PersonalityType.Melancholic;
                return newStats;
            }

            if (newStats.AgreeableScore >= 50)
            {
                newStats.PersonalityType = PersonalityType.Phlegmatic;
                return newStats;
            }

            if (newStats.AssertiveScore >= 50)
            {
                newStats.PersonalityType = PersonalityType.Sanguine;
                return newStats;
            }

            if (newStats.AgreeableScore >= 50)
            {
                newStats.PersonalityType = PersonalityType.Choleric;
                return newStats;
            }

            newStats.PersonalityType = PersonalityType.Melancholic;
            return newStats;
        }
    }
}

