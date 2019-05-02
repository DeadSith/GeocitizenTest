﻿using GeocitizenTest.Framework.Helpers;
using GeocitizenTest.Framework.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeocitizenTest.Framework.Lists
{
    public class UsersList
    {
        protected readonly IWebDriver driver;

        protected By UsersTableLocator => By.CssSelector(".md-table-content table");

        protected By NextPageButtonLocator => By.CssSelector("#buttons > button:nth-child(2) > div");

        protected By PreviousPageButtonLocator => By.CssSelector("#buttons > button:nth-child(1) > div");

        protected By SearchCriteriaInputLocator => By.CssSelector(".md-table-toolbar .md-clearable input");

        protected By UserRoleSelectLocator => By.Id("type-filter");

        protected By RowLocator => By.TagName("tr");

        protected By UserSelectOptionLocator => By.CssSelector(".md-select-menu .md-list-item-text");

        protected By EmptyGridLabelLocator => By.ClassName("md-empty-state-label");

        protected By UserSelectOptionsContainerLocator => By.ClassName("md-select-menu");

        public UsersList(IWebDriver driver)
        {
            this.driver = driver;
            WaitsHelper.WaitUntilElementIsVisible(UsersTableLocator, driver);
        }

        public IWebElement UsersTable => driver.FindElement(UsersTableLocator);

        public IWebElement NextPageButton => driver.FindElement(NextPageButtonLocator);

        public IWebElement PreviousPageButton => driver.FindElement(PreviousPageButtonLocator);

        public IWebElement SearchCriteriaInput => driver.FindElement(SearchCriteriaInputLocator);

        public IWebElement UserRoleSelect => driver.FindElement(UserRoleSelectLocator);

        public IReadOnlyCollection<IWebElement> Rows => UsersTable.FindElements(RowLocator);

        public IReadOnlyCollection<IWebElement> UserSelectOptions => driver.FindElements(UserSelectOptionLocator);

        public void SetUserType(UserType type)
        {
            OpenUserTypeSelect();
            var dropdown = driver.FindElement(UserSelectOptionsContainerLocator);
            var option = ElementsHelper.GetElementsByText(dropdown, type.Label).First();
            option.Click();
        }

        public void OpenUserTypeSelect()
        {
            if (!ElementsHelper.IsElementVisible(UserSelectOptionsContainerLocator, driver))
            {
                UserRoleSelect.Click();
            }
        }

        public IEnumerable<string> UserTypes
        {
            get
            {
                OpenUserTypeSelect();
                return UserSelectOptions.Select(o => o.Text);
            }
        }

        public void SetSearchCriteria(string criteria)
        {
            var element = SearchCriteriaInput;
            element.Clear();
            element.SendKeys(criteria);
        }

        public int GetColumnIndex(UserListColumn columnName)
        {
            var columns = UsersTable.FindElements(By.CssSelector("th > div > div"));
            var i = 1;
            foreach(var column in columns)
            {
                var text = column.Text.Trim();
                if (text == columnName.Name)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public IEnumerable<string> GetColumnValues(int columnIndex)
        {
            var selector = $"tr td:nth-child({columnIndex}) div";
            var cells = UsersTable.FindElements(By.CssSelector(selector));
            var values = cells.Select(c => c.Text);
            return values;
        }

        public IEnumerable<string> GetRowValues(int rowIndex)
        {
            var selector = $"tr:nth-child({rowIndex}) td div";
            var cells = UsersTable.FindElements(By.CssSelector(selector));
            var values = cells.Select(c => c.Text);
            return values;
        }

        public void ClickOnColumnHeader(int columnIndex)
        {
            var selector = $"th:nth-child({columnIndex})";
            var column = UsersTable.FindElement(By.CssSelector(selector));
            column.Click();
        }

        public SortOrder GetSortOrder(int columnIndex)
        {
            var selector = $"th:nth-child({columnIndex})";
            var column = UsersTable.FindElement(By.CssSelector(selector));
            var classNames = column.GetAttribute("class");
            if (classNames.Contains("md-sorted-desc"))
            {
                return SortOrder.Desc;
            }
            else if (classNames.Contains("md-sorted"))
            {
                return SortOrder.Asc;
            }
            return SortOrder.None;
        }
    }
}
