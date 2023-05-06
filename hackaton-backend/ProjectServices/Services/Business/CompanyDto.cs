using System;
using hackatonBackend.ProjectData.Entities;
using hackatonBackend.ProjectServices.Services.Busniess;
using hackatonBackend.ProjectServices.Services.Common.Auth;

namespace hackatonBackend.ProjectServices.Services.Business
{
    public sealed class CompanyDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public DateTime CreatedAt { get; set; }
        public CompanyType? TypeOfCompany { get; set; }

        public UserDto User { get; set; }
    }
}

