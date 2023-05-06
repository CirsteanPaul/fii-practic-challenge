using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectData.Infrastructure.Context;
using hackatonBackend.ProjectData.Infrastructure.Repository;
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
	}
}

