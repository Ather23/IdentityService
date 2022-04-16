using Microsoft.AspNetCore.Mvc;
using Models.Interfaces;
using Newtonsoft.Json;

namespace Models
{
    public class ResponsePayload<T> : IActionResult, IResponsePayload<T> where T : class
    {
        public int StatusCode { get; }
        public T? Payload { get; }

        public ResponsePayload(T payload, int statusCode)
        {
            Payload = payload;
            StatusCode = statusCode;
        }
        public ResponsePayload(T payload, StatusCodeResult statusCodeResult)
        {
            Payload = payload;
            StatusCode = statusCodeResult.StatusCode;
        }


        public async Task ExecuteResultAsync(ActionContext context)
        {
            string? message;
            try
            {
                message = JsonConvert.SerializeObject(Payload);
            }
            catch (Exception)
            {
                //log
                message = "Internal Server Error";
            }

            var objectResult = new ObjectResult(message)
            {
                StatusCode = StatusCode
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
