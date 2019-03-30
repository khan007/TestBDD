using System;
using System.Threading;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestBDD.Transform;
using Xunit;

namespace TestBDD.Steps
{
    [Binding]
    public class CreateEAppFromTablesSteps
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "http://localhost:50553/";
        private readonly ScenarioContext scenarioContext;
        private const int Timeout = 15;

        public CreateEAppFromTablesSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null) throw new ArgumentNullException("scenarioContext");
            this.scenarioContext = scenarioContext;
            _driver = scenarioContext.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I login to URL (.*)")]
        public void GivenILoginToURL(string URL)
        {
            _driver.Navigate().GoToUrl(_url);

            var inputUsername = By.XPath("//*[contains(@id,'UsernameTextBox')]");
            var loginFormSection = _driver.FindElement(inputUsername);

            Assert.NotNull(loginFormSection);
        }
        
        [Given(@"I input enter login (.*)")]
        public void GivenIInputEnterLogin(string login)
        {
            var inputUsername = By.XPath("//*[contains(@id,'UsernameTextBox')]");
            var input = _driver.FindElement(inputUsername);
            input.SendKeys(login);
        }
        
        [Given(@"I input enter password (.*)")]
        public void GivenIInputEnterPassword(string password)
        {
            var inputUsername = By.XPath("//*[contains(@id,'PasswordTextBox')]");
            var input = _driver.FindElement(inputUsername);
            //var input = _driver.FindElement(By.Id("Password"));
            input.SendKeys(password);
        }
        
        [Given(@"I am on (.*)")]
        public void GivenIAmOn(string homePageName)
        {
            var input = _driver.FindElement(By.Id("welcome-user-wrapper"), Timeout);
            Assert.NotNull(input);
            input = _driver.FindElement(By.Id("home"), Timeout);
            Assert.NotNull(input);
        }
        
        [When(@"I press (.*)")]
        public void WhenIPress(string loginButton)
        {
            var inputUsername = By.XPath("//*[contains(@id,'SubmitButton')]");
            var input = _driver.FindElement(inputUsername);

            //input = _driver.FindElement(input);
            input.Click();
        }
        
        [When(@"I click on (.*) button")]
        public void WhenIClickOnButton(string p0)
        {
            var input = _driver.FindElement(By.ClassName("new-eapp"), Timeout);
            Assert.NotNull(input);
            input.Click();
        }
        
        [When(@"I choose (.*) in Issue State")]
        public void WhenIChooseInIssueState(string state)
        {
            //var input = _driver.FindElement(By.Id("SelectedIssueState"), 10);
            // Assert.NotNull(input);
            var input = _driver.FindElement(By.Id("SelectedIssueState_chosen"), Timeout);

            //Assert.NotNull(input);
            input.Click();
            //var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(input);
            input = _driver.FindElement(By.Id("SelectedIssueState_chosen"), Timeout);
            Assert.NotNull(input);
            //".//select[@data-selenium-positionquestion]"
            //var results = input.FindElements(By.ClassName("active-result"));

            var results2 = input.FindElements(By.XPath($".//li[contains(text(),'{state}')]"));
            Assert.NotNull(results2[0]);
            results2[0].Click();

            //select by value
            //selectElement.SelectByValue("Jr.High");
            // select by text
            //selectElement.SelectByText("Alaska");
        }

        [When(@"I enter date of birth (.*) \((.*)\)")]
        public void WhenIEnter(string dateOfBirth, int age)
        {
            dateOfBirth = dateOfBirth.Replace("/", "");

            var input = _driver.FindElement(By.Id("BirthDate"));
            input.Click();
            Assert.NotNull(input);
            input.SendKeys(dateOfBirth);
        }
        
        [When(@"I select gender (.*)")]
        public void WhenISelect(string gender)
        {
            var input = _driver.FindElement(By.Id("Gender_chosen"), Timeout);

            //Assert.NotNull(input);
            input.Click();
            //var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(input);
            input = _driver.FindElement(By.Id("Gender_chosen"), Timeout);
            Assert.NotNull(input);
            //".//select[@data-selenium-positionquestion]"
            //var results = input.FindElements(By.ClassName("active-result"));

            var results2 = input.FindElements(By.XPath($".//li[contains(text(),'{gender}')]"));
            Assert.NotNull(results2[0]);
            results2[0].Click();
        }

        [When(@"I enter firstname (.*)")]
        public void WhenIEnterFirstname(string firstname)
        {
            var input = _driver.FindElement(By.Id("FirstName"));
            Assert.NotNull(input);
            input.SendKeys(firstname);
        }

        [When(@"I enter lastname (.*)")]
        public void WhenIEnterLastname(string lastname)
        {
            var input = _driver.FindElement(By.Id("LastName"));
            Assert.NotNull(input);
            input.SendKeys(lastname);
        }

        [When(@"I (select '.*' product)")]
        public void WhenISelectA(ProductCode productCode)
        {
            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    var table = _driver.FindElement(By.Id("newEApp-results-grid"), Timeout);
                    By by = WebDriverExtensions.SelectorByAttributeValue("data-productcode", $"{productCode.GUID}");
                    var input = table.FindElement(by, _driver, Timeout);
                    Assert.NotNull(input);
                    input.Click();
                    input = table.FindElement(By.ClassName("selected"));
                    if (input != null)
                    {
                        staleElement = false;
                    }
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }
            }
        }

        [When(@"I click on Create button (.*)")]
        public void WhenIClickOnCreateButton(string p0)
        {
            var input = _driver.FindElement(By.Id("new-eapp-open"), Timeout);
            Assert.NotNull(input);
            input.Click();
        }
        
        [Then(@"redirects me to (.*)")]
        public void ThenRedirectsMeTo(string p0)
        {
            
        }
        
        [Then(@"Get redirected to (.*) product")]
        public void ThenGetRedirectedToProduct(string product)
        {
            var input = _driver.FindElement(By.Id("product-name"), Timeout);
            Assert.NotNull(input);
            Assert.Equal(product, input.Text);
        }
    }
}
