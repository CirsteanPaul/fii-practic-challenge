using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Context;
using hackatonBackend.ProjectData.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace hackatonBackend.ProjectData.Repositories
{
	public class GameRepository : Repository<Game>, IGameRepository
	{
		private readonly IAppDbContext dbContext;
		public GameRepository(IAppDbContext dbContext) : base((DbContext)dbContext)
		{
			this.dbContext = dbContext;
		}

		public Game GetGame (int gameId) {
			var game = dbContext.Games
				.FirstOrDefault(x => x.Id == gameId);

			return game;
		}

		public Game GetLatestGame (int userId) {
			var games = dbContext.Games.OrderByDescending(c => c.CreatedAt).Where(g => g.UserId == userId).ToList();

			return games.FirstOrDefault();
		}
	}
}

