namespace Models.Interfaces
{
    public interface IResponsePayload<T> where T : class
    {
        public T Payload { get; }
        public int StatusCode { get; }
    }


}
