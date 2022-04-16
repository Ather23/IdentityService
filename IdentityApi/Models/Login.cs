using IdentityApi.Models.Interfaces;

namespace IdentityApi.Models
{
    public class Login : ILogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
