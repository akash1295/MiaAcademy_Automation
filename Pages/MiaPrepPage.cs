using OpenQA.Selenium;

//This file contains the web elements and functions of the MiaPrep Online High school page
namespace MiaPrepAutomation.Pages
{
    public class MiaPrepPage
    {
        private readonly IWebDriver _driver;

        public MiaPrepPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement ApplyNowButton => _driver.FindElement(By.XPath("//*[@id='kt-layout-id_122039-b8']//a[contains(text(),'Apply to Our School')]"));

        //Clicking on the Apply button for the MiaPrep Online High school
        public void ClickApplyNow()
        {
            ApplyNowButton.Click();
        }
    }
}
