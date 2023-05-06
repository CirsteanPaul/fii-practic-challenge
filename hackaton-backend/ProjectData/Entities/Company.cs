using System;
namespace hackatonBackend.ProjectData.Entities
{
	public sealed class Company
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Logo { get; set; }
		public DateTime CreatedAt { get; set; }
		public short? TypeOfCompany { get; set; }

		public User User { get; set; }
	}
}

