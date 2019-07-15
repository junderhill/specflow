using System;
using TechTalk.SpecFlow;
namespace tests.StepDefinitions
{
    [Binding]
    public class HelloNameSteps
    {
        [Given(@"I have provided my name")]
        public void GivenIHaveProvidedMyName(){
            ScenarioContext.Current.Pending();
        }

        [When(@"I send the request")]
        public void WhenISendTheRequest(){
            ScenarioContext.Current.Pending();
        }

        [Then(@"the result should be Hello Name")]
        public void ThenTheResultShouldBeHelloName(){
            ScenarioContext.Current.Pending();
        }
    }
}