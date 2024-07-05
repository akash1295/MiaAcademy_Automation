using OpenQA.Selenium;

//This file contains the web elements and functions of the Parent Information application page
namespace MiaPrepAutomation.Pages
{
    public class ApplicationPage
    {
        private readonly IWebDriver _driver;

        public ApplicationPage(IWebDriver driver)
        {
            _driver = driver;
        }
        private IWebElement ParentFirstName => _driver.FindElement(By.XPath("//input[@complink='Name_First']"));
        private IWebElement ParentLastName => _driver.FindElement(By.XPath("//input[@complink='Name_Last']"));
        private IWebElement ParentEmail => _driver.FindElement(By.Id("Email-arialabel"));
        private IWebElement ParentPhone => _driver.FindElement(By.Id("PhoneNumber"));
        private IWebElement Guardian => _driver.FindElement(By.XPath("//*[@id='select2-Dropdown-arialabel-container']/div"));
        private IWebElement GuardianYes => _driver.FindElement(By.XPath("//li[contains(text(),'Yes')]"));
        private IWebElement GuardianFirstName => _driver.FindElement(By.XPath("//input[@complink='Name1_First']"));
        private IWebElement GuardianLastName => _driver.FindElement(By.XPath("//input[@complink='Name1_Last']"));
        private IWebElement GuardianEmail => _driver.FindElement(By.Id("Email1-arialabel"));
        private IWebElement GuardianPhone => _driver.FindElement(By.Id("PhoneNumber1"));
        private IWebElement dateSelect => _driver.FindElement(By.XPath("//input[@id='Date-date']"));
        private IWebElement NextButton => _driver.FindElement(By.XPath("//*[@page_link_name='Page']//*[@id='formAccess']/div[1]/div/div/button/em"));

        //Filling the Parent details in the form
        public void FillParentInformation(string firstName, string lastName, string email, string phone)
        {
            ParentFirstName.SendKeys(firstName);
            ParentLastName.SendKeys(lastName);
            ParentEmail.SendKeys(email);
            ParentPhone.SendKeys(phone);
        }

        //Filling the Guardian details in the form
        public void FillGuardianInformation(string firstName, string lastName, string email, string phone)
        {
            Guardian.Click();
            GuardianYes.Click();

            GuardianFirstName.SendKeys(firstName);
            GuardianLastName.SendKeys(lastName);
            GuardianEmail.SendKeys(email);
            GuardianPhone.SendKeys(phone);
        }

        //Choosing referral option
        public void FillOtherDetails(string referral, string date)
        {
            _driver.FindElement(By.XPath("//*[@id='Checkbox-li']//label//*[contains(text(),'"+referral+"')]"));
            dateSelect.SendKeys(date);
        }

        //Clicking on Next to navigate to the next page
        public void ClickNext()
        {
            NextButton.Click();
        }
    }
}
