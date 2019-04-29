using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeocitizenTest.Framework.Pages
{
    public class LoginPage
    {
        protected readonly IWebDriver driver;

        protected IWebElement AuthBox => driver.FindElement(By.Id("authorization"));

        public IWebElement Login => driver.FindElement(By.Id("a-login"));

        public IWebElement Password => driver.FindElement(By.Id("a-password"));

        public IWebElement LogInButton => AuthBox.FindElement(By.CssSelector("button[type='submit']"));

        public void LogIn(string login, string password)
        {
            //wait for box to appear, set values
            //close alert
        }
    }
}
