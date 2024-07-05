using OpenQA.Selenium;

//This file contains the web elements and functions of the Mia Academy homepage
namespace MiaPrepAutomation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement MiaPrepLink => _driver.FindElement(By.LinkText("Online High School"));

        //Launching the Mia Academywebsite
        public void NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl("https://miacademy.co/#/");
        }

        //Clicking on the Online High school link from homepage
        public void ClickOnMiaPrepLink()
        {
            MiaPrepLink.Click();
        }
    }
}
