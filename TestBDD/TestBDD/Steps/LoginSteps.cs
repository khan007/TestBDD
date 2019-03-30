using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Xunit;

namespace TestBDD.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "http://localhost:50553/";
        private readonly ScenarioContext scenarioContext;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            if(scenarioContext == null) throw new ArgumentNullException("scenarioContext");
            this.scenarioContext = scenarioContext;
            _driver = scenarioContext.Get<IWebDriver>("currentDriver");
        }

       [Given(@"I login to URL '(.*)'")]
        public void GivenILoginToURL(string p0)
        {
            _driver.Navigate().GoToUrl(_url);

            var inputUsername = By.XPath("//*[contains(@id,'UsernameTextBox')]");
            var loginFormSection = _driver.FindElement(inputUsername);
            
            Assert.NotNull(loginFormSection);
        }
        
        [Given(@"I input enter login '(.*)'")]
        public void GivenIInputEnterLogin(string login)
        {
            var inputUsername = By.XPath("//*[contains(@id,'UsernameTextBox')]");
            var input = _driver.FindElement(inputUsername);
            input.SendKeys(login);
        }
        
        [Given(@"I input enter password '(.*)'")]
        public void GivenIInputEnterPassword(string password)
        {
            var inputUsername = By.XPath("//*[contains(@id,'PasswordTextBox')]");
            var input = _driver.FindElement(inputUsername);
            //var input = _driver.FindElement(By.Id("Password"));
            input.SendKeys(password);
        }
        
        [When(@"I press '(.*)'")]
        public void WhenIPress(string p0)
        {
            //var input = _driver.FindElement(By.Id("HO"));
            //if (input.GetAttribute("checked") != "checked")
            //{
            //    input.Click();
            //}
            var inputUsername = By.XPath("//*[contains(@id,'SubmitButton')]");
            var input = _driver.FindElement(inputUsername);
            
            //input = _driver.FindElement(input);
            input.Click();
        }
        
        [Then(@"redirects me to '(.*)'")]
        public void ThenRedirectsMeTo(string p0)
        {
            //var input = _driver.FindElement(By.Id("welcome-user-wrapper"), 10);
            //Assert.NotNull(input);

            //scenarioContext.Add("login", _driver);
        }
    }
}
