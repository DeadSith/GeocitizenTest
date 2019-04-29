using GeocitizenTest.Framework.Components;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeocitizenTest.Framework.Pages
{
    public class MainPage
    {
        protected readonly IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected MainToolbar MainToolbar => new MainToolbar(driver);
    }
}
