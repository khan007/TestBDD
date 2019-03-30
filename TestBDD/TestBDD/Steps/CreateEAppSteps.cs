﻿using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;
using TestBDD.Transform;

namespace TestBDD.Steps
{
    [Binding]
    public class CreateEAppSteps
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "http://localhost:50553/";
        private readonly ScenarioContext scenarioContext;
        private const int Timeout = 15;

        public CreateEAppSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null) throw new ArgumentNullException("scenarioContext");
            this.scenarioContext = scenarioContext;
            _driver = scenarioContext.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I am on '(.*)'")]
        public void GivenIAmOn(string p0)
        {
            var input = _driver.FindElement(By.Id("welcome-user-wrapper"), Timeout);
            Assert.NotNull(input);
            input = _driver.FindElement(By.Id("home"), Timeout);
            Assert.NotNull(input);
        }

        [When(@"I click on '(.*)' button")]
        public void WhenIClickOnButton(string p0)
        {
            var input = _driver.FindElement(By.ClassName("new-eapp"), Timeout);
            Assert.NotNull(input);
            input.Click();
        }

        [When(@"I choose '(.*)' State in Issue State")]
        public void WhenIChooseStateInIssueState(string state)
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

        [When(@"I enter '(.*)' Date of Birth \((.*) age\)")]
        public void WhenIEnterDateOfBirthAge(string birthdate, int p1)
        {
            var input = _driver.FindElement(By.Id("BirthDate"));
            input.Click();
            Assert.NotNull(input);
            input.SendKeys(birthdate);
        }

        [When(@"I select Gender '(.*)'")]
        public void WhenISelectGender(string gender)
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
            var input = _driver.FindElement(By.Id("newEApp-results-grid"), Timeout);
            Assert.NotNull(input);
        }

        [When(@"I (select '.*' product)")]
        public void WhenISelectProduct(ProductCode productCode)
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

        [When(@"I click on Create button '(.*)'")]
        public void WhenIClickOnCreateButton(string p0)
        {
            var input = _driver.FindElement(By.Id("new-eapp-open"), Timeout);
            Assert.NotNull(input);
            input.Click();
        }

        [Then(@"Get redirected to '(.*)' product '(.*)'")]
        public void ThenGetRedirectedTo(string p0, string product)
        {
            var input = _driver.FindElement(By.Id("product-name"), Timeout);
            Assert.NotNull(input);
            Assert.Equal(product, input.Text);
        }

        [Given(@"Given I entered the following data into the new account form:")]
        public void EnteredTheFollowingDataIntoTheNewAccountForm(Table table)
        {
            var data = table.ToDictionary();
            
            // account.Name will equal "John Galt", HeightInInches will equal 72, etc.
        }
    }
}
