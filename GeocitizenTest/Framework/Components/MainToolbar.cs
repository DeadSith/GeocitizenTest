using GeocitizenTest.Framework.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeocitizenTest.Framework.Components
{
    public class MainToolbar
    {
        protected readonly IWebDriver driver;

        protected By UserControlDropdownLocator => By.CssSelector("button:not(.md-icon-button)");

        protected By AdministrationButtonLocator => By.CssSelector("li[to='/admin'] a");

        protected By ToolbarEndSectionLocator => By.CssSelector(".md-toolbar-row .md-toolbar-section-end");

        protected By LoginLinkLocator => By.ClassName("a.md-button");

        public MainToolbar(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected IWebElement ToolbarEndSection => driver.FindElement(ToolbarEndSectionLocator);

        public IWebElement LoginLink => ToolbarEndSection.FindElement(LoginLinkLocator);

        public IWebElement UserControlDropdown => ToolbarEndSection.FindElement(UserControlDropdownLocator);

        public IWebElement AdministrationButton => driver.FindElement(AdministrationButtonLocator);

        public void OpenUserControlDropdown()
        {
            if (!ElementsHelper.IsElementVisible(AdministrationButtonLocator, driver))
            {
                UserControlDropdown.Click();
            }
        }
    }
}
