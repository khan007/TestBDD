using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestBDD.Infrastructures;
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
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;
            _driver = scenarioContext.Get<IWebDriver>("currentDriver");
        }

        //[Given(@"I login to URL '(.*)'")]
        //public void GivenILoginToURL(string URL)
        //{
        //    _driver.Navigate().GoToUrl(_url);

        //    var username = "UserName";
        //    var searchPath = string.Format(Constant.SearchInput, username.ToLower());

        //    var inputUsername = By.XPath(searchPath);
        //    var loginFormSection = _driver.FindElement(inputUsername);

        //    Assert.NotNull(loginFormSection);
        //}

        //[Given(@"I input enter login '(.*)'")]
        //public void GivenIInputEnterLogin(string login)
        //{
        //    var username = "UserName";
        //    var searchPath = string.Format(Constant.SearchInput, username.ToLower());

        //    var inputUsername = By.XPath(searchPath);
        //    var input = _driver.FindElement(inputUsername);
        //    input.SendKeys(login);
        //}

        //[Given(@"I input enter password '(.*)'")]
        //public void GivenIInputEnterPassword(string password)
        //{
        //    var passwordID = "password";
        //    var searchPath = string.Format(Constant.SearchInput, passwordID.ToLower());

        //    var inputPassword = By.XPath(searchPath);
        //    var input = _driver.FindElement(inputPassword);
        //    //var input = _driver.FindElement(By.Id("Password"));
        //    input.SendKeys(password);
        //}

        //[When(@"I press '(.*)'")]
        //public void WhenIPress(string p0)
        //{
        //    var submitButton = "SubmitButton";
        //    var button = Constant.SearchInput;
        //    //if (true)
        //    //{
        //    //    submitButton = "logInButton";
        //    //    button = lowerCaseButton;
        //    //}

        //    var submitButtonID = submitButton;
        //    var searchPath = string.Format(button, submitButtonID.ToLower());

        //    var inputButton = By.XPath(searchPath);
        //    var input = _driver.FindElement(inputButton);

        //    //input = _driver.FindElement(input);
        //    input.Click();
        //}

        //[Then(@"redirects me to '(.*)'")]
        //public void ThenRedirectsMeTo(string p0)
        //{
        //    //var input = _driver.FindElement(By.Id("welcome-user-wrapper"), 10);
        //    //Assert.NotNull(input);

        //    //scenarioContext.Add("login", _driver);
        //}

        [Given(@"I login to URL (.*)")]
        public void GivenILoginToURL(string url)
        {
            _driver.Navigate().GoToUrl(_url);

            var username = "UserName";
            var searchPath = string.Format(Constant.SearchInput, username.ToLower());

            var inputUsername = By.XPath(searchPath);
            var loginFormSection = _driver.FindElement(inputUsername);

            Assert.NotNull(loginFormSection);
        }

        [Given(@"I input enter login (.*)")]
        public void GivenIInputEnterLogin(string login)
        {
            var username = "UserName";
            var searchPath = string.Format(Constant.SearchInput, username.ToLower());

            var inputUsername = By.XPath(searchPath);
            var input = _driver.FindElement(inputUsername);
            input.SendKeys(login);
        }

        [Given(@"I input enter password (.*)")]
        public void GivenIInputEnterPassword(string password)
        {
            var passwordID = "password";
            var searchPath = string.Format(Constant.SearchInput, passwordID.ToLower());

            var inputPassword = By.XPath(searchPath);
            var input = _driver.FindElement(inputPassword);
            //var input = _driver.FindElement(By.Id("Password"));
            input.SendKeys(password);
        }

        [When(@"I press (.*)")]
        public void WhenIPress(string loginButton)
        {
            var submitButton = "SubmitButton";
            var button = Constant.SearchInput;
            //if (true)
            //{
            //    submitButton = "logInButton";
            //    button = lowerCaseButton;
            //}

            var submitButtonID = submitButton;
            var searchPath = string.Format(button, submitButtonID.ToLower());

            var inputButton = By.XPath(searchPath);
            var input = _driver.FindElement(inputButton);

            //input = _driver.FindElement(input);
            input.Click();
        }

        [Then(@"redirects me to (.*)")]
        public void ThenRedirectsMeTo(string p0)
        {


        }
    }
}
