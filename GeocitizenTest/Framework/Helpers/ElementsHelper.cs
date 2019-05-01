﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeocitizenTest.Framework.Helpers
{
    public static class ElementsHelper
    {
        public static IReadOnlyCollection<IWebElement> GetElementsByText(IWebElement parent, string text)
        {
            var format = $".//*[contain(text(), '{text}')]";
            var elements = parent.FindElements(By.XPath(format));
            return elements;
        }

        public static bool IsElementVisible(By locator)
        {
            throw new NotImplementedException();
        }
    }
}