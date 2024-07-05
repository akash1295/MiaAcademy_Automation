using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using MiaPrepAutomation.Pages;
using FluentAssertions;

//This Step definition file contains the functions for the Feature file steps
namespace MiaPrepAutomation.Steps
{
    [Binding]
    public class ApplyToMiaPrepSteps
    {
        private IWebDriver driver;
        private HomePage homePage;
        private MiaPrepPage miaPrepPage;
        private ApplicationPage applicationPage;

        [BeforeScenario]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            homePage = new HomePage(driver);
            miaPrepPage = new MiaPrepPage(driver);
            applicationPage = new ApplicationPage(driver);
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [Given(@"User navigates to the Mia Academy website")]
        public void UserNavigatesToTheMiaAcademyWebsite()
        {
            try
            {
                homePage.NavigateToHomePage();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An error occurred while navigating to the Mia Academy website: {ex.Message}");
            }
        }

        [When(@"User navigates to MiaPrep Online High School through the link on banner")]
        public void UserNavigatesToMiaPrepOnlineHighSchoolThroughTheLinkOnBanner()
        {
            try
            {
                homePage.ClickOnMiaPrepLink();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An error occurred while clicking on MiaPrep Online High School through the link on banner: {ex.Message}");
            }
        }

        [When(@"User applies to MOHS")]
        public void UserAppliesToMOHS()
        {
            try
            {
                miaPrepPage.ClickApplyNow();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An error occurred while clicking on the Apply button: {ex.Message}");
            }
        }

        [When(@"User fills in the Parent Information")]
        public void UserFillsInTheParentInformation()
        {
            try
            {
                applicationPage.FillParentInformation("Andy", "Allen", "andy.allen@miamail.com", "3569845456");
                applicationPage.FillGuardianInformation("Jock", "Zonfrillo", "jock.zonfrillo@miamail.com", "8256975120");
                applicationPage.FillOtherDetails("Word of mouth", "01-Sep-2024");
                applicationPage.ClickNext();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An error occurred while filling the Parent Information form: {ex.Message}");
            }
        }

        [Then(@"User should proceed to the Student Information page")]
        public void UserShouldProceedToTheStudentInformationPage()
        {
            try
            {
                IWebElement studentInfoHeader = driver.FindElement(By.XPath("//*[@id='Section3-li']/h2/div/b"));
                studentInfoHeader.Text.Should().Be("Student Information", "because the Student Information header should be displayed");
                Console.WriteLine("Landed on Student Information page successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail($"An error occurred while navigating to the Student Information page: {ex.Message}");
            }
        }

        [Then(@"User stops the test")]
        public void StopTheTest()
        {
            Console.WriteLine("End of Execution!!!");
        }
    }
}
