using System.Net;

namespace SM.Identity.API.Models
{
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
}
