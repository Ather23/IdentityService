namespace DataLayer.Models.Interfaces
{
    public interface IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
