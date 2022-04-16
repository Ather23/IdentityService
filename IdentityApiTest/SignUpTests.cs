using DbLayer;
using IdentityApi.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using Xunit;

namespace IdentityApiTest
{
    public class SignUpTests : BaseTest
    {
        private SignUpController _signUpController;
        private readonly UserManager<ApplicationUser> _appUserManager;

        public SignUpTests()
        {
            _appUserManager = _serviceProvider.GetService<UserManager<ApplicationUser>>();
            _signUpController = new SignUpController(_appUserManager);
        }

        [Fact]
        public async Task SignUp_ShouldReturnOkResult_WhenUserSignUp()
        {
            var userPayload = new RequestPayload<SignUpInfo>()
            {
                PayLoad = new SignUpInfo()
                {
                    UserName = $"Ather{Guid.NewGuid().ToString()[0..10]}",
                    Email = "ather@gmail.com",
                    Password = "123password##"
                }
            };
            ActionResult result = await _signUpController.SignUp(userPayload);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task SignUp_ShouldReturnBadResult_WhenUserNameExists()
        {
            var userPayload = new RequestPayload<SignUpInfo>()
            {
                PayLoad = new SignUpInfo()
                {
                    UserName = "Ather231",
                    Email = "ather@gmail.com",
                    Password = "123password##"
                }
            };
            ActionResult result = await _signUpController.SignUp(userPayload);
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}
