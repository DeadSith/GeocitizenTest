using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace GeocitizenTest.Framework.Helpers
{
    public static class WaitsHelper
    {
        public static void WaitUntilElementIsVisible(By locator, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => ElementsHelper.IsElementVisible(locator, d));
        }

        public static void WaitUntilAlertIsPresent(IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
            {
                try
                {
                    return driver.SwitchTo().Alert();
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            });
        }

        public static void WaitUntilElementIsHidden(By locator, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => ElementsHelper.IsElementHidden(locator, d));
        }
    }
}
