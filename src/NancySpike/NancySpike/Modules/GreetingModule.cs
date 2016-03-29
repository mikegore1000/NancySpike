using Nancy;
using NancySpike.Models;

namespace NancySpike.Modules
{
    public class GreetingModule : NancyModule
    {
        public GreetingModule()
        {
            Get["/"] = parameters => new ResponseMessage { Greeting = "Hello World" };
        }
    }
}