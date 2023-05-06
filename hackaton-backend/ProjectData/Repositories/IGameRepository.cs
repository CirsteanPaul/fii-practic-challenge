using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Repository;

namespace hackatonBackend.ProjectData.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        Game GetGame(int gameId);
        Game GetLatestGame(int userId);
    }
}