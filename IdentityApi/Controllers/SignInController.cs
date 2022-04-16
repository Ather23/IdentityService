using DbLayer;
using IdentityApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace IdentityApi
{
    [ApiController]
    [Route("[controller]")]
    public class SignInController : ControllerBase
    {
        private readonly static Serilog.ILogger log = Log.ForContext(typeof(SignInController));
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SignInController(SignInManager<ApplicationUser> signInManager)
        {
            log.Error("In sign in controller");
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignInAsync(IRequestPayload<Login> requestPayload)
        {

            var payload = requestPayload.PayLoad;
            var signIn = await _signInManager.PasswordSignInAsync(payload.UserName, payload.Password, false, false);
            if (signIn.Succeeded)
            {
                return Ok("SignIn Success");
            }
            else
            {
                return BadRequest("Error");
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
