using GeocitizenTest.Framework.Lists;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeocitizenTest.Framework.Pages
{
    public class AdministrationPage
    {
        protected readonly IWebDriver driver;

        public AdministrationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public By UsersButtonLocator => By.CssSelector("li[to='/admin/users'] a");

        public IWebElement UsersButton => driver.FindElement(UsersButtonLocator);

        public UsersList OpenUsersList()
        {
            UsersButton.Click();
            var list = new UsersList(driver);
            return list;
        }
    }
}
