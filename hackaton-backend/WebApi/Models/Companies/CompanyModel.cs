using System;
using hackatonBackend.ProjectServices.Services.Busniess;
using hackatonBackend.ProjectServices.Services.Common.Auth;

namespace hackatonBackend.WebApi.Models.Companies
{
	public sealed class CompanyModel
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public DateTime CreatedAt { get; set; }
        public CompanyType? TypeOfCompany { get; set; }

        public UserModel User { get; set; }
    }
}

