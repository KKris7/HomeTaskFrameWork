using HomeTaskFrameWork.Utilities;
using OpenQA.Selenium;

namespace HomeTaskFrameWork.Pages
{
    internal class CareersPage : BasePage
    {
        private readonly IWebDriver _webDriver;

        internal CareersPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }
        /* Locators */
        private By _jobList => By.XPath("//*[@id=\"post-1762\"]/div/div/section[6]/div/div/div/div/div/div/article");
        private By _jobBy(string text) => By.XPath($"//a[normalize-space()='{text}']");

        /* Elements */
        internal List<IWebElement> JobList => _webDriver.FindElements(_jobList).ToList();
        internal BaseElement JobBy(string text) => new BaseElement(_webDriver, _jobBy(text));

        /* Methods */
    }
}
