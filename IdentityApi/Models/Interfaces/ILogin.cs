namespace IdentityApi.Models.Interfaces
{
    public interface ILogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
