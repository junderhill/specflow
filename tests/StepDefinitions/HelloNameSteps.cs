using System;
using System.Net.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow;
namespace tests.StepDefinitions
{
    [Binding]
    public class HelloNameSteps
    {
        private HttpClient client;
        private HttpResponseMessage result;
        private string queryString;

        private void SetupTestServer(){
            var factory = new WebApplicationFactory<api.Startup>();
            client = factory.CreateClient(); 
        }

        [Given(@"I have provided my name")]
        public void GivenIHaveProvidedMyName(){
            SetupTestServer();
            queryString = "?name=jason";
        } 

        [When(@"I send the request")]
        public async void WhenISendTheRequest(){
            result = await client.GetAsync($"/api/hello{queryString}");
        }

        [Then(@"the result should be Hello Name")]
        public async void ThenTheResultShouldBeHelloName(){
            var resultString = await result.Content.ReadAsStringAsync();
            resultString.Should().Match("hello jason");
        }
    }
}