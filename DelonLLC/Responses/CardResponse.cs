using System.Net;

namespace DelonLLC.Responses
{
    public class Response
    {
        public HttpStatusCode status { get; set; }

        public string? message { get; set; }

        public bool success { get; set; } = false;
    }

    public class CardResponse<T>: Response
    {
        public T? data { get; set; }
    }

    public class CardResponseResult<T>: Response
    {
        public IEnumerable<T>? data { get; set; }
    }

}
