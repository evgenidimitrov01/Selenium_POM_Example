using OpenQA.Selenium;
namespace Selenium_Homework.PageObjects
{
    public class AddStudentsPage : BasePage
    {
        public AddStudentsPage(IWebDriver driver) : base(driver)
        {
           
        }
        public override string PageUrl => "https://mvc-app-node-express.evgenidimitrov0.repl.co/add-student";

        public IWebElement FieldName =>
           driver.FindElement(By.Id("name"));

        public IWebElement FieldEmail =>
           driver.FindElement(By.Id("email"));

        public IWebElement ButtonSubmit =>
            driver.FindElement(By.CssSelector("button[type='submit']"));

        public IWebElement ErrorMsg =>
            driver.FindElement(By.XPath("//div[contains(@style, 'background:red')]"));

        public void AddStudent(string name, string email)
        {
            this.FieldName.SendKeys(name);
            this.FieldEmail.SendKeys(email);
            this.ButtonSubmit.Click();
        }

    }
}
