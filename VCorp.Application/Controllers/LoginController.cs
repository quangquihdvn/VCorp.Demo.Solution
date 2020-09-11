using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VCorp.Demo.Service.Services.Login;
using VCorp.Demo.ViewModels.Common;

namespace VCorp.Demo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        public readonly ILoginService _loginService;
        public LoginController(
            ILoginService loginService
            )
        {
            _loginService = loginService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate()
        {
            var result = _loginService.Authencate();
            return Ok(new ApiSuccessResult<string>(result));
        }
    }
}
