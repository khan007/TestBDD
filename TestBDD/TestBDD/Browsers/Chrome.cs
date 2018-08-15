using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace TestBDD.Browsers
{
    public class Chrome : BasePage
    {
        //private IWebDriver driver;
        private static IWebDriver _driver;

        //Contructor to re-use the driver
        public Chrome(IWebDriver _driver) : base(_driver)
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments(new List<string>() { "headless"});

            //chromeOptions.AddArguments(new List<string>() {
            //    "--silent-launch",
            //    "--no-startup-window",
            //    "no-sandbox",
            //    "headless",});

            _driver = new ChromeDriver(driverService, new ChromeOptions());
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl("url");
        }

        //public void SearchOperation(string keyword)
        //{
        //    // Find the text input element by its name
        //    IWebElement query = WebBrowser.Current.FindElement(By.Name("q"));
        //    // Input the search text
        //    query.SendKeys(keyword);
        //    // Now submit the form
        //    query.Submit();
        //    // Google's search is rendered dynamically with JavaScript.
        //    // Wait for the page to load, timeout after 5 seconds
        //    WebDriverWait wait = new WebDriverWait(WebBrowser.Current, TimeSpan.FromSeconds(5));
        //    IWebElement title = wait.Until<IWebElement>((d) =>
        //    {
        //        return d.FindElement(By.ClassName("ab_button"));
        //    });
        //}
    }
}