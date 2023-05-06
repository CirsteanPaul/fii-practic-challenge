using System;
using hackatonBackend.ProjectServices.Services.Questions;
using hackatonBackend.WebApi.Mappers;
using hackatonBackend.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.WebApi.Controllers
{
	public class RespondRequest {
		public int GameId { get; set; }
		public int QuestionId { get; set; }
		public int Answer { get; set; }
	}
	[Route("api/questions")]
	public class QuestionController : ApplicationController
	{
		private readonly IQuestionService questionService;

		public QuestionController(IQuestionService questionService)
		{
			this.questionService = questionService;
		}

		[HttpPost("create")]
		public ActionResult<GameResponse> CreateNewGame() {
			questionService.CreateNewGame(UserId);
			var latestGame = questionService.GetLatestGameByUser(UserId);
			var newQuestion = questionService.GetNewQuestion(latestGame.Id);
			var questions = questionService.GetHistoryQuestions(latestGame.Id);

			return QuestionMapper.ToModel(latestGame, questions, newQuestion);
		}

		[HttpPost("respond")]
        public ActionResult<GameResponse> RespondQuestion([FromBody] RespondRequest request)
        {
			questionService.RespondQuestion(request.GameId, request.QuestionId, request.Answer);
            var latestGame = questionService.GetLatestGameByUser(UserId);
            var newQuestion = questionService.GetNewQuestion(latestGame.Id);
            var questions = questionService.GetHistoryQuestions(latestGame.Id);

			var response = QuestionMapper.ToModel(latestGame, questions, newQuestion);

			return response;
        }
    }
}

