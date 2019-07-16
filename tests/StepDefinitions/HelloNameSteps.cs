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

        [Given(@"I have provided a name (.*)")]
        public void GivenIHaveProvidedMyName(string name){
            queryString = $"?name={name}";
        } 
        [Given(@"I have not provided my name")]
        public void GivenIHaveNotProvidedMyName(){
            queryString = string.Empty;
        } 

        [When(@"I send the request")]
        public async Task WhenISendTheRequest(){
            result = await client.GetAsync($"api/hello{queryString}");
        }

        [Then(@"the result should be (.*)")]
        public async Task ThenTheResultShouldBeHelloName(string expectedGreeting)
        {
            result.EnsureSuccessStatusCode();
            var resultString = await result.Content.ReadAsStringAsync();
            resultString.Should().Match(expectedGreeting);
        }

        [Then(@"the result should just be Hello")]
        public async Task ThenTheResultShouldBeHello()
        {
            result.EnsureSuccessStatusCode();
            var resultString = await result.Content.ReadAsStringAsync();
            resultString.Should().Match("\"Hello\"");
        }
    }
}