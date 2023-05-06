using System;
namespace hackatonBackend.WebApi.Models.Jobs
{
	public sealed class JobModel
	{
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}

