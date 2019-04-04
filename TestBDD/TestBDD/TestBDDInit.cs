using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace TestBDD
{
    [Binding]
    public class GeneralHooks
    {
        private ScenarioContext scenarioContext;
        private FeatureContext featureContext;
        private IWebDriver _driver;

        [BeforeScenario]
        public void RunBeforeScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            DisposeDriverService.TestRunStartTime = DateTime.Now;

            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }
            this.scenarioContext = scenarioContext;
            this.featureContext = featureContext;


            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var chromeOptions = new ChromeOptions();

            chromeOptions.AddArguments(new List<string>() { "headless", "disable-gpu" });

//#if DEBUG
//            chromeOptions = new ChromeOptions();
//#endif
            _driver = new ChromeDriver(driverService, chromeOptions);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();

            scenarioContext.Add("currentDriver", _driver);
        }

        [AfterScenario]
        public void RunAfterScenario()
        {
            if (scenarioContext.TestError != null)
            {
                TakeScreenshot(_driver);
            }
            _driver.Dispose();
            //DisposeDriverService.FinishHim(_driver);
         //   _driver?.Quit();
        }

        private void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                var fileNameBase = string.Format("error_{0}_{1}_{2}", featureContext.FeatureInfo.Title.ToIdentifier(), scenarioContext.ScenarioInfo.Title.ToIdentifier(), DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "testresults");
                if (!Directory.Exists(artifactDirectory))
                {
                    Directory.CreateDirectory(artifactDirectory);
                }

                var pageSource = driver.PageSource;
                var sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));

                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();

                    string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

                    screenshot.SaveAsFile(screenshotFilePath,ScreenshotImageFormat.Png);

                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
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