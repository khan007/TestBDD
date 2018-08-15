using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TestBDD
{
    [Binding]
    public class GeneralHooks
    {
        private ScenarioContext scenarioContext;
        private IWebDriver _driver;

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var chromeOptions = new ChromeOptions();
            _driver = new ChromeDriver(driverService, new ChromeOptions());

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();

            ScenarioContext.Current.Add("currentDriver", _driver);
        }

        [AfterScenario]
        public void RunAfterScenario()
        {
            //_driver?.Quit();
        }
    }
}