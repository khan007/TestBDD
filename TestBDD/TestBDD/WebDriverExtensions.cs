using System;
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
                //var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("content-section")));

                var element = wait.Until(condition =>
                {
                    try
                    {
                        var elementToBeDisplayed = driver.FindElement(by);
                        return elementToBeDisplayed.Displayed;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return false;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                });
            }
            return driver.FindElement(by);
        }
        public static By SelectorByAttributeValue(string attributeName, string attributeValue)
        {
            return (By.XPath($"//*[@{attributeName} = '{attributeValue}']"));
        }
    }
}
