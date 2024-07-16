using HomeTaskFrameWork.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HomeTaskFrameWork.StepDefinitions
{
    [Binding]
    internal class CareersPageStepDefinitions
    {
        private readonly CareersPage _careerPage;
        private readonly IWebDriver _webDriver;

        internal CareersPageStepDefinitions(IWebDriver webDriver)
        {
            _careerPage = new CareersPage(webDriver);
            _webDriver = webDriver;
        }

        [Then(@"the Careers page should load correctly")]
        internal void ThenTheCareersPageShouldLoadCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_webDriver.Url, Is.EqualTo("https://strypes.eu/careers/"), "Unexpected URL.");
                Assert.That(_webDriver.Title, Is.EqualTo("Careers - Strypes"), "Unexpected title.");
            });
        }

        [Then(@"The user should see job listings displayed")]
        internal void ThenIShouldSeeJobListingsDisplayed()
        {
            Assert.That(_careerPage.JobList.Count, Is.GreaterThan(1), "No job listings found.");
        }

        [When(@"The user clicks on a '(.*)' job listing")]
        internal void WhenIClickOnAJobListing(string jobTitle)
        {
            _careerPage.JobBy(jobTitle).Click();
        }
    }
}
