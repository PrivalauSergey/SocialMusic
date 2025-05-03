using System.Net;

namespace SM.Channel.API.Client.Models
{
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
}
