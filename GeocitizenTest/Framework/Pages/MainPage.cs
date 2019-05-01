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

        public MainToolbar MainToolbar => new MainToolbar(driver);

        public LoginPage OpenLoginPage()
        {
            var toolbar = MainToolbar;
            toolbar.LoginLink.Click();
            return new LoginPage(driver);
        }

        public AdministrationPage OpenAdministrationPage()
        {
            var toolbar = MainToolbar;
            toolbar.OpenUserControlDropdown();
            toolbar.AdministrationButton.Click();
            return new AdministrationPage(driver);
        }
    }
}
