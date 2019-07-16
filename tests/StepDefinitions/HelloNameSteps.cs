using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using api;
using FluentAssertions;
using TechTalk.SpecFlow;
namespace tests.StepDefinitions
{
    [Binding]
    public class HelloNameSteps
    {
        private HttpResponseMessage result;
        private string queryString;
        private HttpClient client;

        public HelloNameSteps(CustomWebApplicationFactory factory)
        {
            client = factory.CreateClient();
        }

        [Given(@"I have provided my name")]
        public void GivenIHaveProvidedMyName(){
            queryString = "?name=jason";
        } 

        [When(@"I send the request")]
        public async Task WhenISendTheRequest(){
            result = await client.GetAsync($"api/hello");
        }

        [Then(@"the result should be Hello Name")]
        public async Task ThenTheResultShouldBeHelloName()
        {
            result.EnsureSuccessStatusCode();
            var resultString = await result.Content.ReadAsStringAsync();
            resultString.Should().Match("hello jason");
        }
    }
}