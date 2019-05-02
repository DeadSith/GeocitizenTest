using GeocitizenTest.Framework.Helpers;
using GeocitizenTest.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeocitizenTest.Framework
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void TestInit()
        {
            ReportHelper.Instance.Initialize();
            driver = CreateDriver();
        }

        public MainPage OpenMainPage()
        {
            driver.Navigate().GoToUrl("http://geocitizen.herokuapp.com");
            WaitsHelper.WaitUntilAlertIsPresent(driver);
            driver.SwitchTo().Alert().Accept();
            return new MainPage(driver);
        }

        [TearDown]
        public void StopBrowser()
        {
            ReportHelper.Instance.FinalizeReport();
            driver.Quit();
        }

        protected virtual IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            options.AddArguments("incognito");
            var driver = new ChromeDriver(options);
            return driver;
        }
    }
}
