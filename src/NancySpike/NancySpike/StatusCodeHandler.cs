using Nancy;
using Nancy.ErrorHandling;

namespace NancySpike
{
    // Shows how we can intercept responses and manipulate the content - we typically just return a 404 status code with no content which is what
    // this code below handles for you.
    public class StatusCodeHandler : IStatusCodeHandler
    {
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            context.Response.Contents = stream => { };
        }
    }
}