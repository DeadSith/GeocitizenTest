using GeocitizenTest.Framework.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeocitizenTest.Framework.Pages
{
    public class LoginPage
    {
        protected readonly IWebDriver driver;

        protected By AuthBoxLocator => By.Id("authorization");

        protected By LoginLocator => By.Id("a-login");

        protected By PasswordLocator => By.Id("a-password");

        protected By LogInButtonLocator => By.CssSelector("#authorization button[type='submit']");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            WaitsHelper.WaitUntilElementIsVisible(AuthBoxLocator, driver);
        }

        public IWebElement LogInButton => driver.FindElement(LogInButtonLocator);

        public void LogIn(string login, string password)
        {
            var authBox = driver.FindElement(AuthBoxLocator);
            var loginInput = authBox.FindElement(LoginLocator);
            var passwordInput = authBox.FindElement(PasswordLocator);

            loginInput.Clear();
            loginInput.SendKeys(login);

            passwordInput.Clear();
            passwordInput.SendKeys(password);

            LogInButton.Click();

            WaitsHelper.WaitUntilAlertIsPresent(driver);
            driver.SwitchTo().Alert().Accept();
        }

        public void LogInAsAdmin()
        {
            LogIn("Admin_123", "Admin_123");
        }
    }
}
