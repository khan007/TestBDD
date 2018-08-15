using System;
using OpenQA.Selenium;

namespace TestBDD.Browsers
{
    public class BasePage
    {
        private static IWebDriver _driver;
        private readonly string WebUrl;

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