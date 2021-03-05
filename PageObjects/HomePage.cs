using OpenQA.Selenium;

namespace Selenium_Homework.PageObjects
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
           
        }
        public override string PageUrl => "https://mvc-app-node-express.evgenidimitrov0.repl.co/";

        public IWebElement ElementStudentsCount =>
           driver.FindElement(By.CssSelector("body > p > b"));

        public int GetStudentsCount()
        {
            string studentsCountText = this.ElementStudentsCount.Text;
            return int.Parse(studentsCountText);
        }

    }
}
