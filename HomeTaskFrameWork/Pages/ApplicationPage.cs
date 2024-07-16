using HomeTaskFrameWork.Utilities;
using OpenQA.Selenium;

namespace HomeTaskFrameWork.Pages
{
    internal class ApplicationPage
    {
        private readonly IWebDriver _webDriver;

        internal ApplicationPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        /* Locators */
        private By _requiredFields => By.XPath("//small[@class='text-danger'][normalize-space()='This field is required.']");
        private By _submitApplicationButton => By.Id("submit-id-submit");

        /* Elements */
        internal List<IWebElement> RequiredFieldsList => _webDriver.FindElements(_requiredFields).ToList();
        internal BaseElement SubmitApplicationButton => new BaseElement(_webDriver, _submitApplicationButton);

        /* Methods */
    }
}
