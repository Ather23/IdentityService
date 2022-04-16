namespace IdentityApi.Models
{
    public interface IRequestPayload<T> where T : class
    {
        public T PayLoad { get; set; }
    }
}
