using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Testing;
using NancySpike.Models;
using NUnit.Framework;

namespace NancySpike.Tests
{
    [TestFixture]
    public class GreetingModuleTests
    {
        [Test]
        public void Should_Return_A_202_With_Greeting()
        {
            var bootstrapper = new Bootstrapper();
            var browser = new Browser(bootstrapper);

            var result = browser.Get("/", with =>
            {
                with.HttpRequest();
                with.Header("Content-Type", "application/json");
            });

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
            var body = result.Body.DeserializeJson<ResponseMessage>();
            Assert.That(body, Is.Not.Null);
            Assert.That(body.Greeting, Is.EqualTo("Hello World"));
        }
    }
}
