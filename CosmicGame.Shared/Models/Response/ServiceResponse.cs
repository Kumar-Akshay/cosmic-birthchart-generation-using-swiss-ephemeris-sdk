using System.Net;

namespace CosmicGame.Shared.Models.Response
{
    public class ServiceResponse
    {
        public HttpStatusCode status { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public object result { get; set; }
    }
}
