namespace NancySpike.Services
{
    public interface IGreetingService
    {
        string GetGreeting();
    }

    public class GreetingService : IGreetingService
    {
        public string GetGreeting()
        {
            return "Hello World";
        }
    }
}