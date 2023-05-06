using System;
namespace hackatonBackend.ProjectData.Entities
{
	public sealed class Cv
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string GeneralSkills { get; set; }
		public string ExtracurricularActivities { get; set; }
		public string Experience { get; set; }
	}
}

