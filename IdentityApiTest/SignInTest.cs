using DbLayer;
using IdentityApi;
using IdentityApi.Models;
using IdentityApi.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace IdentityApiTest
{
    public class SignInTest : BaseTest
    {
        private SignInController _signInController;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public SignInTest()
        {
            _signInManager = _serviceProvider.GetService<SignInManager<ApplicationUser>>();
            _signInManager.Context = new DefaultHttpContext { RequestServices = _serviceProvider };
            _signInController = new SignInController(_signInManager);
        }

        [Fact]
        public async Task SignInAsync_ShouldReturnOk_WhenUserCredsMatch()
        {
            var result = await _signInController.SignInAsync(new RequestPayload<Login>()
            {
                PayLoad = new Login()
                {
                    UserName = "Ather23114",
                    Password = "123password##"
                }
            });

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task SignInAsync_ShouldReturnBadResult_WhenUserCredsDontMatch()
        {
            var result = await _signInController.SignInAsync(new RequestPayload<Login>()
            {
                PayLoad = new Login()
                {
                    UserName = "UserNameDoesNotExist",
                    Password = "123password##"
                }
            });

            Assert.IsType<BadRequestObjectResult>(result);
        }


    }
}