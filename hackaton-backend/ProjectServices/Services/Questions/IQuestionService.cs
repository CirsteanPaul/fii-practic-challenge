using System;
using hackatonBackend.ProjectData;
using hackatonBackend.ProjectData.Entities;

namespace hackatonBackend.ProjectServices.Services.Questions
{
    public interface IQuestionService
    {
        Question GetNewQuestion(int gameId);
        IEnumerable<Question> GetHistoryQuestions(int gameId);
        Game GetGameById(int gameId);
        Game GetLatestGameByUser(int? userId);
        void CreateNewGame(int? userId);
        void RespondQuestion(int gameId, int questionId, int answer);
    }
}