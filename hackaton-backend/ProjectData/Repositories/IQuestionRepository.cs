using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Repository;
using hackatonBackend.ProjectServices.Services.Questions;

namespace hackatonBackend.ProjectData.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetAllQuestionWithParams(QuestionMetrics metrics);
        IEnumerable<Question> GetAllQuestionsOfGame(Game game);
        Question GetQuestionById(int id);
    }
}