using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using Nancy;
using Nancy.ErrorHandling;
using NancySpike.Models;
using NancySpike.Services;

namespace NancySpike.Modules
{
    public class GreetingModule : NancyModule
    {
        // Don't have to provide backing fields for services as all your routing to handlers is done via the constructor.
        // Also, don't have to write any boilerplate to register a particular type of DI container, out of the box Nancy uses the TinyIOC container
        // and is setup to wire any interface to the concrete type - assuming a 1:1 mapping which is the case in most scenarios.
        public GreetingModule(IGreetingService greetingService)
        {
            Get["/"] = parameters =>
            {
                // Can just create a response, but this disables content negotiation (may or may not be required)
                // Accepted status code is just to show how we can override status codes using the Response.AsX methods
                return Response.AsJson(new ResponseMessage {Greeting = greetingService.GetGreeting()}, HttpStatusCode.Accepted);

                // Just showing off that we can use negotiate to vary status codes whilst still using content negotiation.
                //return Negotiate
                //    .WithStatusCode(HttpStatusCode.Accepted)
                //    .WithModel(new ResponseMessage {Greeting = greetingService.GetGreeting()}, HttpStatusCode.Accepted));
            };

            // Use the _ to show you aren't interested in the parameters
            // See https://github.com/NancyFx/Nancy/wiki/Taking-a-look-at-the-DynamicDictionary
            Get["/404test"] = _ => Response.AsJson<object>(null, HttpStatusCode.NotFound);
        }
    }
}