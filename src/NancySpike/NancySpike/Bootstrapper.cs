using Nancy.Bootstrapper;
using Nancy.Responses.Negotiation;

namespace NancySpike
{
    using Nancy;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                // Overridden the processors to ensure only JSON responses are returned
                // otherwise Nancy will try to return HTML when the browser requests content.
                // Don't have to do this, especially if you use a REST client to manually call the service.
                var processors = new[] { typeof(JsonProcessor) };

                return NancyInternalConfiguration.WithOverrides(x => x.ResponseProcessors = processors);
            }
        }
    }
}