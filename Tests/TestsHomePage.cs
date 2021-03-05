using NUnit.Framework;
using Selenium_Homework.PageObjects;
using Selenium_Homework.Tests;

namespace Selenium_Homework
{
    [TestFixture]
    public class TestsHomePage : TestsBase
    {
        [Test]
        [Category("Home Students Page")]
        public void Test_HomePage_Content()
        {
            var page = new HomePage(driver);
            page.Open();

            Assert.AreEqual("MVC Example", page.GetPageTitle());
            Assert.AreEqual("Students Registry", page.GetPageHeadingText());
            page.GetStudentsCount();
            Assert.Pass();
        }

        [Test]
        [Category("Home Students Page")]
        public void Test_HomePage_Links()
        {
            var page = new HomePage(driver);
            page.Open();

            page.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentsPage(driver).IsOpen());
            driver.Navigate().Back();

            page.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
            driver.Navigate().Back();

            Assert.IsTrue(new HomePage(driver).IsOpen());

        }
    }
}