using System;
using hackatonBackend.ProjectServices.Services.Common.Auth;

namespace hackatonBackend.ProjectServices.Services.Recruits
{
	public sealed class ApplicationDto
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JobId { get; set; }
        public int? CvId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserDto User { get; set; }
    }
}

