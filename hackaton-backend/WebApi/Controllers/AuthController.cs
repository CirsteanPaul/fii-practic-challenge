using hackatonBackend.ProjectServices.Services.Common.Auth;
using hackatonBackend.WebApi.Mappers;
using hackatonBackend.WebApi.Models.Authentication;
using hackatonBackend.WebApi.Models.Common;
using hackatonBackend.WebApi.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hackatonBackend.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authenticationService;

        public AuthController(IAuthService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResponseModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public ActionResult<LoginResponse> LoginUser([FromBody] LoginRequest login)
        {
            var token = authenticationService.LoginUser(login.Username, login.Password);
            return Ok(new LoginResponse(token));
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult RegisterUser([FromBody] RegisterRequest registerRequest)
        {
            var registerDto = registerRequest.ToDto();
            authenticationService.RegisterUser(registerDto);

            return StatusCode(201);
        }
    }
}
