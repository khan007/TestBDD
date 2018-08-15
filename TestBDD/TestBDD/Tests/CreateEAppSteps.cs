using System;
using TechTalk.SpecFlow;

namespace TestBDD.Tests
{
    [Binding]
    public class CreateEAppSteps
    {
        [When(@"I click Create button '(.*)'")]
        public void WhenIClickCreateButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
