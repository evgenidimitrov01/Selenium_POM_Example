using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Homework.PageObjects
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        public virtual string PageUrl { get; }
        public BasePage(IWebDriver driver) 
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        public IWebElement LinkHomePage =>
            driver.FindElement(By.XPath("//a[contains(.,'Home')]"));

        public IWebElement LinkViewStudentsPage =>
            driver.FindElement(By.XPath("//a[contains(.,'View Students')]"));

        public IWebElement LinkAddStudentsPage =>
            driver.FindElement(By.XPath("//a[contains(.,'Add Student')]"));

        public IWebElement PageHeading =>
            driver.FindElement(By.CssSelector("body > h1"));

        public void Open()
        {
            driver.Navigate().GoToUrl(this.PageUrl);
        }

        public bool IsOpen()
        {
            return driver.Url == this.PageUrl;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPageHeadingText()
        {
            return PageHeading.Text;
        }

    }
}
