using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Model.Auth;
using Streaming.Application.Utilities.Extensions;
using Streaming.Business.Interfaces;

namespace Streaming.API.Contollers.V1
{
    [ApiVersion("1")]
    [ApiController]
    [Route("v1")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")] //
        public IActionResult Login(AuthenticateRequest model)
        {
            var (serviceResult, user) = _authService.Login(model.UserName, model.Password);
            if (!serviceResult.IsSuccess) 
                return this.FailedFromServiceResult(serviceResult);

            var token = _authService.CreateToken(user);
            return Ok(token);
        }

    }
}
