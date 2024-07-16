using HomeTaskFrameWork.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace HomeTaskFrameWork.StepDefinitions
{
    [Binding]
    internal class ApplicationPageStepDefinitions
    {
        private readonly ApplicationPage _applicationPage;
        private readonly IWebDriver _webDriver;

        internal ApplicationPageStepDefinitions(IWebDriver webDriver)
        {
            _applicationPage = new ApplicationPage(webDriver);
            _webDriver = webDriver;
        }

        [When(@"The user clicks on the submit application button")]
        internal void WhenIFillInAndSubmitTheJobApplicationForm()
        {
            Actions actions = new Actions(_webDriver);
            actions.MoveToElement(_applicationPage.SubmitApplicationButton.WebElement).Perform();
            _applicationPage.SubmitApplicationButton.Click();
        }

        [Then(@"Validation messages are displayed")]
        internal void ThenValidationMessagesAreDisplayed()
        {
            Assert.That(_applicationPage.RequiredFieldsList.Count, Is.EqualTo(6), "Expected 6 validation messages, but found a different number.");
        }
    }
}
