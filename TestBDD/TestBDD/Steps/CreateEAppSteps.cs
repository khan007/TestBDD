using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Xunit;

namespace TestBDD
{
    [Binding]
    public class CreateEAppSteps
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "http://localhost:50553/";

        public CreateEAppSteps()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I am on '(.*)'")]
        public void GivenIAmOn(string p0)
        {
            var input = _driver.FindElement(By.Id("welcome-user-wrapper"), 10);
            Assert.NotNull(input);
            input = _driver.FindElement(By.Id("home"), 10);
            Assert.NotNull(input);
        }
        
        [When(@"I click on '(.*)' button")]
        public void WhenIClickOnButton(string p0)
        {
            var input = _driver.FindElement(By.ClassName("new-eapp"), 10);
            Assert.NotNull(input);
            input.Click();
        }
        
        [When(@"I choose '(.*)' State in Issue State")]
        public void WhenIChooseStateInIssueState(string p0)
        {
            //var input = _driver.FindElement(By.Id("SelectedIssueState"), 10);
           // Assert.NotNull(input);
            var input = _driver.FindElement(By.Id("SelectedIssueState_chosen"), 10);
            
            //Assert.NotNull(input);
            input.Click();
            //var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(input);
            input = _driver.FindElement(By.Id("SelectedIssueState_chosen"), 10);
            Assert.NotNull(input);
            //".//select[@data-selenium-positionquestion]"
            //var results = input.FindElements(By.ClassName("active-result"));

            var results2 = input.FindElements(By.XPath(".//li[contains(text(),'Colorado')]"));
            Assert.NotNull(results2[0]);
            results2[0].Click();
            
            //select by value
            //selectElement.SelectByValue("Jr.High");
            // select by text
            //selectElement.SelectByText("Alaska");
        }
        
        [When(@"I enter '(.*)' Date of Birth \((.*) age\)")]
        public void WhenIEnterDateOfBirthAge(string p0, int p1)
        {
            var input = _driver.FindElement(By.Id("BirthDate"));
            input.Click();
            Assert.NotNull(input);
            input.SendKeys(p0);
        }
        
        [When(@"I select Gender '(.*)'")]
        public void WhenISelectGender(string p0)
        {
            //var input = _driver.FindElement(By.Id("Gender"), 10);
            //Assert.NotNull(input);
            //var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(input);
            //Assert.NotNull(selectElement);
            ////select by value
            ////selectElement.SelectByValue("Jr.High");
            //// select by text
            //selectElement.SelectByText("Male");
            ////ScenarioContext.Current.Pending();
            ///
            var input = _driver.FindElement(By.Id("Gender_chosen"), 10);

            //Assert.NotNull(input);
            input.Click();
            //var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(input);
            input = _driver.FindElement(By.Id("Gender_chosen"), 10);
            Assert.NotNull(input);
            //".//select[@data-selenium-positionquestion]"
            //var results = input.FindElements(By.ClassName("active-result"));

            var results2 = input.FindElements(By.XPath(".//li[contains(text(),'Male')]"));
            Assert.NotNull(results2[0]);
            results2[0].Click();
        }
        
        [When(@"I enter Firstname '(.*)'")]
        public void WhenIEnterFirstname(string p0)
        {
            var input = _driver.FindElement(By.Id("FirstName"));
            Assert.NotNull(input);
            input.SendKeys(p0);
        }
        
        [When(@"I enter Lastname '(.*)'")]
        public void WhenIEnterLastname(string p0)
        {
            var input = _driver.FindElement(By.Id("LastName"));
            Assert.NotNull(input);
            input.SendKeys(p0);
        }

        [Then(@"a popup appears with list of products")]
        public void ThenAPopupAppearsWithListOfProducts()
        {
            var input = _driver.FindElement(By.Id("newEApp-results-grid"), 10);
            Assert.NotNull(input);
        }

        [When(@"I select '(.*)' product")]
        public void WhenISelectProduct(string p0)
        {
            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    var table = _driver.FindElement(By.Id("newEApp-results-grid"), 10);
                    var input = table.FindElement(WebDriverExtensions.SelectorByAttributeValue("data-productcode", "CC52408C-6464-11E0-A34B-BBDDDED72085"));

                    table = _driver.FindElement(By.Id("newEApp-results-grid"), 10);
                    input = table.FindElement(WebDriverExtensions.SelectorByAttributeValue("data-productcode", "CC52408C-6464-11E0-A34B-BBDDDED72085"));
                    Assert.NotNull(input);
                    input.Click();
                }
                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                }

                staleElement = false;
            }
            
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on Create button '(.*)'")]
        public void WhenIClickOnCreateButton(string p0)
        {
            var input = _driver.FindElement(By.Id("new-eapp-open"), 10);
            Assert.NotNull(input);
            input.Click();
        }
        
        [Then(@"Get redirects me to '(.*)'")]
        public void ThenGetRedirectsMeTo(string p0)
        {
            var input = _driver.FindElement(By.Id("product-name"), 10);
            Assert.NotNull(input);
            Assert.Equal("HMS Plus 100", input.Text);
        }
    }
}
