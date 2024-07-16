using HomeTaskFrameWork.Utilities;
using OpenQA.Selenium;

namespace HomeTaskFrameWork.Pages
{
    internal class ContactPage : BasePage
    {
        private readonly IWebDriver _webDriver;

        internal ContactPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        /* Locators */
        private By _sendButton => By.CssSelector("input[value='SEND']");
        private By _contactFormInputFieldBy(string label) => By.XPath($"//input[@id='{label.ToLower()}-9246f6ce-b893-4249-8362-96d17c0861f5']");
        private By _privacyCheckBox => By.XPath("//input[@id='LEGAL_CONSENT.subscription_type_4681882-9246f6ce-b893-4249-8362-96d17c0861f5']");
        private By _subscribeCheckBox => By.XPath("//input[@id='LEGAL_CONSENT.subscription_type_4673944-9246f6ce-b893-4249-8362-96d17c0861f5']");
        private By _confirmationMessage => By.XPath("//div[@class='hbspt-form'][normalize-space()='Thank you for submitting the form.']");
        private By _emailValidationMessage => By.XPath("//*[@id=\"hsForm_9246f6ce-b893-4249-8362-96d17c0861f5\"]/fieldset[2]/div/ul/li/label");

        /* Elements */
        internal BaseElement SendButton => new BaseElement(_webDriver, _sendButton);
        internal BaseElement PrivacyCheckBox => new BaseElement(_webDriver, _privacyCheckBox);
        internal BaseElement SubscribeCheckBox => new BaseElement(_webDriver, _subscribeCheckBox);
        internal BaseElement ConfirmationMessage => new BaseElement(_webDriver, _confirmationMessage);
        internal BaseElement EmailValidationMessage => new BaseElement(_webDriver, _emailValidationMessage);
        internal BaseElement ContactFormInputFieldBy(string label) => new BaseElement(_webDriver, _contactFormInputFieldBy(label));

        /* Methods */
    }
}
