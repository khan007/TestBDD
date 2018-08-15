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

        public LoginSteps()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
        }

       [Given(@"I login to URL '(.*)'")]
        public void GivenILoginToURL(string p0)
        {
            _driver.Navigate().GoToUrl(_url);
            
            var loginFormSection = _driver.FindElement(By.Id("loginForm"));
            Assert.NotNull(loginFormSection);
        }
        
        [Given(@"I input enter login '(.*)'")]
        public void GivenIInputEnterLogin(string login)
        {
            var input = _driver.FindElement(By.Id("UserName"));
            input.SendKeys(login);
        }
        
        [Given(@"I input enter password '(.*)'")]
        public void GivenIInputEnterPassword(string password)
        {
            var input = _driver.FindElement(By.Id("Password"));
            input.SendKeys(password);
        }
        
        [When(@"I press '(.*)'")]
        public void WhenIPress(string p0)
        {
            var input = _driver.FindElement(By.Id("HO"));
            if (input.GetAttribute("checked") != "checked")
            {
                input.Click();
            }

            input = _driver.FindElement(By.Id("logInButton"));
            input.Click();
        }
        
        [Then(@"redirects me to '(.*)'")]
        public void ThenRedirectsMeTo(string p0)
        {
            var input = _driver.FindElement(By.Id("welcome-user-wrapper"), 10);
            Assert.NotNull(input);

            ScenarioContext.Current.Add("login", _driver);
        }
    }
}
