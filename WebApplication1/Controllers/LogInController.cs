using Consultation.Service.IService;
using Consunltation.API.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Consunltation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogInController : ControllerBase
    {
        private readonly IAuthService _authServices;
        public LogInController(IAuthService authServices) { _authServices = authServices; }

        [HttpPost]
        public async Task<IActionResult> GetUser([FromBody] UserViewModel users)
        {
            var appUsers = await _authServices.Login(users.UserName, users.Password, users.UserType.ToString());
            if (appUsers == null)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }
            return Ok(appUsers);
        }
    }
}
