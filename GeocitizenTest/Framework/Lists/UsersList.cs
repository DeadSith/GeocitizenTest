using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeocitizenTest.Framework.Lists
{
    public class UsersList
    {
        protected readonly IWebDriver driver;

        public IWebElement UsersTable => driver.FindElement(By.CssSelector(".md-table-content table"));

        public IWebElement NextPageButton => null;

        public IWebElement PreviousPageButton => null;

        public IWebElement SearchCriteriaInput => driver.FindElement(By.CssSelector(".md-table-toolbar .md-clearable input"));

        public IWebElement UserRoleSelect => driver.FindElement(By.Id("type-filter"));

        public IEnumerable<IWebElement> UserRoleOptions => driver.FindElements(By.CssSelector(".md-select-menu li"));
    }
}
