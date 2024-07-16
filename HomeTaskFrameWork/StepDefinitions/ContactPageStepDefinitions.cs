using HomeTaskFrameWork.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HomeTaskFrameWork.StepDefinitions
{
    [Binding]
    internal class ContactPageStepDefinitions
    {
        private readonly ContactPage _contactPage;
        private readonly IWebDriver _webDriver;

        internal ContactPageStepDefinitions(IWebDriver webDriver)
        {
            _contactPage = new ContactPage(webDriver);
            _webDriver = webDriver;
        }

        [Then(@"the Contact page should load correctly")]
        internal void ThenTheContactPageShouldLoadCorrectly()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_webDriver.Url, Is.EqualTo("https://strypes.eu/contact/"), "Unexpected URL.");
                Assert.That(_webDriver.Title, Is.EqualTo("Contact - Strypes"), "Unexpected title.");
            });
        }

        [When(@"The user clicks on the send button")]
        internal void WhenIClickOnTheSendButton()
        {
            _contactPage.SendButton.Click();
        }

        [When(@"The user fills in the '(.*)' field with '(.*)'")]
        internal void WhenIFillInTheFieldWith(string field, string inputText)
        {
            var inputField = _contactPage.ContactFormInputFieldBy(field);
            inputField.ClearText();
            inputField.InputText(inputText);
        }

        [When(@"The user checks the checkbox '(.*)'")]
        internal void WhenICheckTheCheckbox(string checkBox)
        {
            if (checkBox.Equals("privacy"))
            {
                _contactPage.PrivacyCheckBox.Click();
            }
            else if (checkBox.Equals("subscribe"))
            {
                _contactPage.SubscribeCheckBox.Click();
            }
            else
            {
                throw new Exception($"Please try again, no checkbox with name: {checkBox}");
            }
        }

        [When(@"The user accepts the Alert")]
        internal void WhenIPressEnter()
        {
            IAlert alert = _webDriver.SwitchTo().Alert();
            alert.Accept();
        }

        [Then(@"The user should see a confirmation message")]
        internal void ThenIShouldSeeAConfirmationMessage()
        {
            Assert.That(_contactPage.ConfirmationMessage.IsDisplayed(), Is.True, "Confirmation message not displayed.");
        }

        [Then(@"Validation message is displayed:'(.*)' for the email field")]
        internal void ThenValidationMessageIsDisplayedForTheField(string validationText)
        {
            Assert.That(validationText, Is.EqualTo(_contactPage.EmailValidationMessage.GetElementText()), "Email validation message mismatch.");
        }
    }
}
