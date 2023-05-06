using System;
namespace hackatonBackend.ProjectServices.Services.Jobs
{
	public sealed class CreateJobDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int? UserId { get; set; }
	}
}

