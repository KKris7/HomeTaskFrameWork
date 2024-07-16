using HomeTaskFrameWork.Utilities;
using OpenQA.Selenium;

namespace HomeTaskFrameWork.Pages
{
    internal class JobsPage : BasePage
    {
        private readonly IWebDriver _webDriver;

        internal JobsPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        /* Locators */
        private By _jobTitleBy(string text) => By.XPath($"//h1[normalize-space()='{text}']");
        private By _applyNowButton => By.CssSelector(".elementor-button-text");

        /* Elements */
        internal BaseElement JobTitleBy(string text) => new BaseElement(_webDriver, _jobTitleBy(text));
        internal BaseElement ApplyButton => new BaseElement(_webDriver, _applyNowButton);

        /* Methods */
    }
}
