using System;
namespace hackatonBackend.WebApi.Models
{
	public class QuestionModel
	{
		public int Id { get; set; }
		public string Question { get; set; }
		public string Answer1 { get; set; }
		public string Answer2 { get; set; }
		public string Answer3 { get; set; }
	}
}

