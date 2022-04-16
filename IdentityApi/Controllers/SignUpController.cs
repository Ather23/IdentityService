using DbLayer;
using IdentityApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Serilog;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("Register")]
    public class SignUpController : ControllerBase
    {
        private readonly static Serilog.ILogger log = Log.ForContext(typeof(SignUpController));
        private readonly UserManager<ApplicationUser> _userManager;

        public SignUpController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost(Name = "SignUp")]
        public async Task<ActionResult> SignUp(IRequestPayload<SignUpInfo> requestPayload)
        {
            var user = requestPayload.PayLoad;
            var hasher = new PasswordHasher<IdentityUser>();
            IdentityUser identityUser = new IdentityUser(user.UserName);

            IdentityResult result = await _userManager.CreateAsync(new ApplicationUser()
            {
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = hasher.HashPassword(identityUser, user.Password)
            });
            if (result.Succeeded)
            {
                return Ok("SignUp Success");
            }
            else
            {
                //log
                return BadRequest("Unable to SignUp");
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
