using HomeTaskFrameWork.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HomeTaskFrameWork.StepDefinitions
{
    [Binding]
    internal class JobsPageStepDefinitions
    {
        private readonly JobsPage _jobPage;
        private readonly IWebDriver _webDriver;

        internal JobsPageStepDefinitions(IWebDriver webDriver)
        {
            _jobPage = new JobsPage(webDriver);
            _webDriver = webDriver;
        }

        [Then(@"the job details should be displayed")]
        internal void ThenTheJobDetailsShouldBeDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_jobPage.JobTitleBy("Automation Quality Assurance Engineer").IsDisplayed(), Is.True, "Job title not displayed.");
                Assert.That(_jobPage.TitleBy("We have awesome plans for you!").IsDisplayed(), Is.True, "Plans title not displayed.");
                Assert.That(_jobPage.TitleBy("JOB DESCRIPTION").IsDisplayed(), Is.True, "Job description not displayed.");
            });
        }

        [When(@"The user clicks on the apply button")]
        internal void WhenIClickOnTheApplyButton()
        {
            _jobPage.ApplyButton.Click();
        }
    }
}
