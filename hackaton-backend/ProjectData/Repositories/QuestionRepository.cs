using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Context;
using hackatonBackend.ProjectData.Infrastructure.Repository;
using hackatonBackend.ProjectServices.Services.Questions;
using Microsoft.EntityFrameworkCore;

namespace hackatonBackend.ProjectData.Repositories
{
	public class QuestionRepository : Repository<Question> , IQuestionRepository
	{
		private readonly IAppDbContext dbContext;

		public QuestionRepository(IAppDbContext dbContext) : base((DbContext)dbContext)
		{
			this.dbContext = dbContext;
		}

		public IEnumerable<Question> GetAllQuestionWithParams(QuestionMetrics metrics) {
			var newQuestionMetrics = new QuestionMetrics
			{
				MinimumAgreeableScore = metrics.MinimumAgreeableScore.HasValue ? metrics.MinimumAgreeableScore.Value : 0,
				MinimumAssertieScore = metrics.MinimumAssertieScore.HasValue ? metrics.MinimumAssertieScore.Value : 0,
				MinimumPshycologyScore = metrics.MinimumAgreeableScore.HasValue ? metrics.MinimumPshycologyScore.Value : 0,
				MiniumCalmScore = metrics.MinimumAgreeableScore.HasValue ? metrics.MiniumCalmScore.Value : 0,
			};

			return dbContext.Questions
				.Where(q =>
				q.MinimumAgreeableScore >= newQuestionMetrics.MinimumAgreeableScore.Value ||
				q.MinimumAssertieScore >= newQuestionMetrics.MinimumAssertieScore.Value ||
				q.MinimumPshycologyScore >= newQuestionMetrics.MinimumPshycologyScore.Value  ||
				q.MiniumCalmScore >= newQuestionMetrics.MiniumCalmScore.Value)
				.ToList();
		}
		public Question GetQuestionById(int id) {
			return dbContext.Questions.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Question> GetAllQuestionsOfGame(Game game) {
            var questions = dbContext.Questions.Where(q =>
            q.Id == game.QuestionId1 ||
            q.Id == game.QuestionId2 ||
            q.Id == game.QuestionId3 ||
            q.Id == game.QuestionId4 ||
            q.Id == game.QuestionId5 ||
            q.Id == game.QuestionId6 ||
            q.Id == game.QuestionId7 ||
            q.Id == game.QuestionId8 ||
            q.Id == game.QuestionId9 ||
            q.Id == game.QuestionId10)
            .ToList();

            return questions;
        }
    }
}

