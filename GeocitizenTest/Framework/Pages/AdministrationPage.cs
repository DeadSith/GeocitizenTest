using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeocitizenTest.Framework.Pages
{
    public class AdministrationPage
    {
        protected readonly IWebDriver driver;

        public IWebElement UsersButton => driver.FindElement(By.CssSelector("li[to='/admin/users'] a"));
    }
}
