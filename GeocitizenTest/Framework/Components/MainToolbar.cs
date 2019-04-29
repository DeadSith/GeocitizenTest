using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeocitizenTest.Framework.Components
{
    public class MainToolbar
    {
        protected readonly IWebDriver driver;

        public MainToolbar(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected IWebElement ToolbarEndSection => driver.FindElement(By.CssSelector(".md-toolbar-row .md-toolbar-section-end"));

        public IWebElement LoginLink => ToolbarEndSection.FindElement(By.TagName("a"));

        public IWebElement UserControlDropdown => ToolbarEndSection.FindElement(By.CssSelector("button:not(.md-icon-button)"));

        public IWebElement AdministrationButton => driver.FindElement(By.CssSelector("li[to='/admin'] a"));
    }
}
