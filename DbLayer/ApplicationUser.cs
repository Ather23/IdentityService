using Microsoft.AspNetCore.Identity;

namespace DbLayer
{
    public class ApplicationUser : IdentityUser
    {
        public string? AccountType { get; set; }
        public string? CustomAttribute { get; set; }
    }
}
