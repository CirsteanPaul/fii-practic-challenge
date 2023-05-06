using System;
using hackatonBackend.ProjectServices.Services.Users;
using hackatonBackend.WebApi.Mappers;
using hackatonBackend.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.WebApi.Controllers
{
	[Route("/api/users")]
	public class UserController : ApplicationController
	{
		private readonly IUserService userService;

		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		[HttpGet("details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public ActionResult<UserDetailsModel> GetUserDetails()
		{
			var userDto = userService.GetDetails(UserId);

			return Ok(userDto.ToApiModel());
		}

		[HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
		public ActionResult ChangeUserDetails([FromBody] UserDetailsModel changes)
		{
			userService.ChangeDetails(UserId, changes.ToDto());

			return Ok();
		}
    }
}

