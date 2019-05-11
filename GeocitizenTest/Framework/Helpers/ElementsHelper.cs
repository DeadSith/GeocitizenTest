using OpenQA.Selenium;
using System.Collections.Generic;

namespace GeocitizenTest.Framework.Helpers
{
    public static class ElementsHelper
    {
        public static IReadOnlyCollection<IWebElement> GetElementsByText(IWebElement parent, string text)
        {
            var format = $".//*[contains(text(), '{text}')]";
            var elements = parent.FindElements(By.XPath(format));
            return elements;
        }

        public static bool IsElementVisible(By locator, IWebDriver driver)
        {
            var elements = driver.FindElements(locator);
            if (elements.Count == 0)
            {
                return false;
            }
            return elements[0].Displayed;
        }

        public static bool IsElementHidden(By locator, IWebDriver driver)
        {
            var elements = driver.FindElements(locator);
            if (elements.Count == 0)
            {
                return true;
            }
            return !elements[0].Displayed;
        }
    }
}
