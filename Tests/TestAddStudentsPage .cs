using NUnit.Framework;
using OpenQA.Selenium;
using Selenium_Homework.PageObjects;
using Selenium_Homework.Tests;
using System;
using System.Text;

namespace Selenium_Homework
{
    [TestFixture]
    public class TestAddStudentsPage : TestsBase
    {
        [Test]
        [Category("Add Students Page")]
        public void Test_AddStudents_Content()
        {
            var page = new AddStudentsPage(driver);
            page.Open();

            Assert.AreEqual("Add Student", page.GetPageTitle());
            Assert.AreEqual("Register New Student", page.GetPageHeadingText());

            Assert.AreEqual("", page.FieldEmail.Text);
            Assert.AreEqual("", page.FieldName.Text);
            Assert.AreEqual("Add", page.ButtonSubmit.Text);
        }

        [Test]
        [Category("Add Students Page")]
        public void Test_AddStudents_Links()
        {
            var page = new AddStudentsPage(driver);
            page.Open();

            page.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());
            driver.Navigate().Back();

            page.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());
            driver.Navigate().Back();

            Assert.IsTrue(new AddStudentsPage(driver).IsOpen());
        }

        [Test]
        [Category("Add Students Page")]
        public void Test_AddValidStudent()
        {
            var page = new AddStudentsPage(driver);
            page.Open();

            Guid id = Guid.NewGuid();
            string StudentName = Helpers.Helpers.RandomString(10);
            string name = StudentName + id;
            string email = StudentName + id + "@mail.bg";

            page.AddStudent(name, email);
            var viewStudentsPage = new ViewStudentsPage(driver);
            Assert.IsTrue(viewStudentsPage.IsOpen());

            var students = viewStudentsPage.GetRegisteredStudents();
            string newStudent = name + " (" + email + ")";
            Assert.Contains(newStudent, students);
        }

        [Test]
        [Category("Add Students Page")]
        public void Test_AddInvalidStudent()
        {
            var page = new AddStudentsPage(driver);
            page.Open();

            string name = string.Empty;
            string email = Helpers.Helpers.RandomString(10) + "@mail.bg";

            page.AddStudent(name, email);
            Assert.IsTrue(page.IsOpen());
            Assert.IsTrue(page.ErrorMsg.Text.Contains("Cannot add student"));
        }

        [Test]
        [Category("Add Students Page")]
        public void Test_AddNotVisibleNameCharsStudent()
        {
            var page = new AddStudentsPage(driver);
            page.Open();

            byte[] byteChars = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F};
            string name = Encoding.ASCII.GetString(byteChars);
            string email = "Student_Email@mail.bg";

            page.AddStudent(name, email);

            Assert.IsTrue(page.IsOpen());
            Assert.IsTrue(page.ErrorMsg.Text.Contains("Cannot add student"));
        }

        [Test]
        [Category("Add Students Page")]
        public void Test_AddTagNameAndMailStudent()
        {
            var page = new AddStudentsPage(driver);
            page.Open();

            string name = "<b>Student name with tag</b> <br />";
            string email = "<h1>Student_Email<h1>@mail.bg";

            page.AddStudent(name, email);
            var viewStudentsPage = new ViewStudentsPage(driver);
            viewStudentsPage.Open();
            Assert.IsTrue(viewStudentsPage.IsOpen());

            var students = viewStudentsPage.GetRegisteredStudents();
            string newStudent = name + " (" + email + ")";
            CollectionAssert.DoesNotContain(students, newStudent);
        }

        [Test]
        [Category("Add Students Page")]
        public void Test_AddFakeMailStudent()
        {
            var page = new AddStudentsPage(driver);
            page.Open();

            string name = "Evgeni";
            string email = "This is invalid email!";

            //Change Email field type to 'text'
            //Test checks if the backend have protection for invalid email
            //Because there is no such check - the test fail!
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('email').setAttribute('type', 'text')");

            page.AddStudent(name, email);
            var viewStudentsPage = new ViewStudentsPage(driver);
            viewStudentsPage.Open();
            Assert.IsTrue(viewStudentsPage.IsOpen());

            var students = viewStudentsPage.GetRegisteredStudents();
            string newStudent = name + " (" + email + ")";
            CollectionAssert.DoesNotContain(students, newStudent);
        }

    }
}