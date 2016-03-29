using Nancy;
using NancySpike.Models;

namespace NancySpike.Modules
{
    public class GreetingModule : NancyModule
    {
        public GreetingModule()
        {
            Get["/"] = parameters =>
            {
                return Negotiate
                    .WithStatusCode(HttpStatusCode.Accepted)
                    .WithModel(new ResponseMessage { Greeting = "Hello World" });
            };
        }
    }
}