using NUnit.Framework;
using Selenium_Homework.PageObjects;
using Selenium_Homework.Tests;

namespace Selenium_Homework
{
    [TestFixture]
    public class TestViewStudentsPage : TestsBase
    {
        [Test]
        [Category("View Students Page")]
        public void Test_ViewStudents_Content()
        {
            var page = new HomePage(driver);
            page.Open();

            Assert.AreEqual("MVC Example", page.GetPageTitle());
            Assert.AreEqual("Students Registry", page.GetPageHeadingText());
            page.GetStudentsCount();
            Assert.Pass();
        }

        [Test]
        [Category("View Students Page")]
        public void Test_ViewStudents_Links()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();

            page.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());
            driver.Navigate().Back();

            page.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentsPage(driver).IsOpen());
            driver.Navigate().Back();

            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
        }

        [Test]
        [Category("View Students Page")]
        public void Test_RegisteredStudents()
        {
            var page = new ViewStudentsPage(driver);
            page.Open();
            var students = page.GetRegisteredStudents();
            foreach (string st in students)
            {
                Assert.IsTrue(st.IndexOf("(") > 0);
                Assert.IsTrue(st.LastIndexOf(")") == st.Length -1);
            }
        }
    }
}