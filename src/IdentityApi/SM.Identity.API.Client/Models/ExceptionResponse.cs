using System.Net;

namespace SM.Identity.API.Client.Models
{
    public class ExceptionResponse : ApiResponse
    {
        public HttpStatusCode Code { get; set; }
        public string ExceptionMessage { get; set; }
        public string State { get; set; }
    }
}
