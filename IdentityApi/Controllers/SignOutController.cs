using IdentityApi.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace IdentityApi
{
    [ApiController]
    [Route("[controller]")]
    public class SignOutController : ControllerBase
    {
        private readonly static Serilog.ILogger log = Log.ForContext(typeof(SignOutController));

        public SignOutController()
        {
            log.Error("In sign in controller");
        }

        [HttpPost]
        public async Task<IActionResult> SignOut(IRequestPayload<Login> requestPayload)
        {
            return Ok("success");
        }
    }
}
