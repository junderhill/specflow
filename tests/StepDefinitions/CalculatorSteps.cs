using System;
using FluentAssertions;
using System.Net.Http;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace tests.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {
        private HttpClient client;
        private int first;
        private int second;
        private int sum;
        private readonly ITestOutputHelper testOutputHelper;

        public CalculatorSteps(CustomWebApplicationFactory factory, ITestOutputHelper testOutputHelper)
        {
            client = factory.CreateClient();
            this.testOutputHelper = testOutputHelper;
        }

        [Given(@"Values (.*) and (.*)")]
        public void GivenTwoValues(int p0, int p1)
        {
            first = p0;
            second = p1; 
        }

        [When(@"Users calls the Add endpoint")]
        public async System.Threading.Tasks.Task WhenUsersCallsTheAddEndpointAsync()
        {
            var result = await client.GetAsync($"api/calculator/add?first={first}&second={second}");
            var resultcontent = await result.Content.ReadAsStringAsync();
            resultcontent = resultcontent.Replace("\"","");
            testOutputHelper.WriteLine(resultcontent);
            sum = int.Parse(resultcontent);
        }

        [Then(@"I should received a response of (.*)")]
        public void ThenIShouldReceivedAResponseOf(int p0)
        {
            sum.Should().Equals(p0);
        }
    }
}