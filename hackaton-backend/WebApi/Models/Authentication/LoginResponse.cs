namespace hackatonBackend.WebApi.Models.Authentication
{
    public sealed class LoginResponse
    {
        public LoginResponse(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
