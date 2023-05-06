using System;
namespace hackatonBackend.ProjectData.Entities
{
	public sealed class Application
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int JobId { get; set; }
		public int? CvId { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }

		public User User { get; set; }
		public Job Job { get; set; }
	}
}

