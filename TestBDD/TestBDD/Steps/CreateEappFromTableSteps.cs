using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace TestBDD.Steps
{
    [Binding]
    public class CreateEappFromTableSteps : LoginSteps
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "http://localhost:50553/";
        private readonly ScenarioContext scenarioContext;
        private const int Timeout = 15;

        public CreateEappFromTableSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            if (scenarioContext == null) throw new ArgumentNullException("scenarioContext");
            this.scenarioContext = scenarioContext;
            _driver = scenarioContext.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I entered the following data into the new account form:")]
        public void GivenIEnteredTheFollowingDataIntoTheNewAccountForm(Table table)
        {
            var data = table.ToDictionary();
            GivenILoginToURL(_url);
        }
        
        [Then(@"Successful create eapp and a message should display")]
        public void ThenSuccessfulCreateEappAndAMessageShouldDisplay()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
