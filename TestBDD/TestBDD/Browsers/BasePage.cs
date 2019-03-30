using System;
using OpenQA.Selenium;
using System.Configuration;

namespace TestBDD.Browsers
{
    public class BasePage
    {
        private static IWebDriver _driver;
        private readonly string WebUrl;

        public static string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["BaseUrl"]; }
        }

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToUrl()
        {
            _driver.Navigate().GoToUrl(WebUrl);
        }
    }
}