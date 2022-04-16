namespace IdentityApi.Models.Interfaces
{
    public class RequestPayload<T> : IRequestPayload<T> where T : class
    {
        public T PayLoad { get; set; }
    }
}
