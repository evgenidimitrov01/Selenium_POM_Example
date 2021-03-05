using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Selenium_Homework.PageObjects
{
    public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
           
        }
        public override string PageUrl => "https://mvc-app-node-express.evgenidimitrov0.repl.co/students";

        public List<IWebElement> ListItemStudents=>
            driver.FindElements(By.CssSelector("body > ul > li")).ToList();

        public string[] GetRegisteredStudents()
        {
            var elementsStudents = this.ListItemStudents.Select(s => s.Text).ToArray();
            return elementsStudents;
        }

    }
}
