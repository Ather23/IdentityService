namespace DbLayer.Interfaces
{
    public interface IApplicationUser
    {
        public string? AccountType { get; set; }
        public string? CustomAttribute { get; set; }
    }
}
