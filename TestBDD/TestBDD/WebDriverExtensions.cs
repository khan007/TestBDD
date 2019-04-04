using System;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestBDD
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                //return wait.Until(drv => drv.FindElement(by));

                //var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return element;
                //var element = wait.Until(condition =>
                //{
                //    try
                //    {
                //        var elementToBeDisplayed = driver.FindElement(by);
                //        return elementToBeDisplayed.Displayed;
                //    }
                //    catch (StaleElementReferenceException)
                //    {
                //        return false;
                //    }
                //    catch (NoSuchElementException)
                //    {
                //        return false;
                //    }
                //});
            }
            return driver.FindElement(by);
        }

        public static IWebElement FindElement(this IWebElement webElement, By by, IWebDriver driver, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                {
                    PollingInterval = TimeSpan.FromMilliseconds(100)
                };
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return element;
            }
            return driver.FindElement(by);
        }
        public static By SelectorByAttributeValue(string attributeName, string attributeValue)
        {
            return (By.XPath($"//*[@{attributeName} = '{attributeValue}']"));
        }

        public static string TakeScreenshot(this IWebDriver driver, string prefix)
        {
            var fileName = String.Format("{0}{1}{2}", prefix, DateTime.Now.ToString("HHmmss"), ".png");
            var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            return fileName;
        }
    }
}
