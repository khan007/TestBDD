using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void RunBeforeScenario(ScenarioContext scenarioContext)
        {
            DisposeDriverService.TestRunStartTime = DateTime.Now;

            if (scenarioContext == null) throw new ArgumentNullException("scenarioContext");
            this.scenarioContext = scenarioContext;

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var chromeOptions = new ChromeOptions();

            chromeOptions.AddArguments(new List<string>() { "headless", "disable-gpu" });

#if DEBUG
            chromeOptions = new ChromeOptions();
#endif
            _driver = new ChromeDriver(driverService, chromeOptions);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            

            scenarioContext.Add("currentDriver", _driver);
        }

        [AfterScenario]
        public void RunAfterScenario()
        {
            _driver.Dispose();
            //DisposeDriverService.FinishHim(_driver);
         //   _driver?.Quit();
        }

        public void Dispose()
        {
            DisposeDriverService.FinishHim(_driver);
        }
    }

    public static class DisposeDriverService
    {
        private static readonly List<string> _processesToCheck =
            new List<string>
            {
                "opera",
                "chrome",
                "firefox",
                "ie",
                "gecko",
                "phantomjs",
                "edge",
                "microsoftwebdriver",
                "webdriver"
            };
        public static DateTime? TestRunStartTime { get; set; }
        public static void FinishHim(IWebDriver driver)
        {
            driver?.Dispose();
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                try
                {
                    Debug.WriteLine(process.ProcessName);
                    if (process.StartTime > TestRunStartTime)
                    {
                        var shouldKill = false;
                        foreach (var processName in _processesToCheck)
                        {
                            if (process.ProcessName.ToLower().Contains(processName))
                            {
                                shouldKill = true;
                                break;
                            }
                        }
                        if (shouldKill)
                        {
                            process.Kill();
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }
    }
}