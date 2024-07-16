using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace HomeTaskFrameWork.Utilities
{
    internal class BaseElement
    {
        private readonly IWebDriver _webDriver;
        private readonly By _byLocator;
        internal IWebElement WebElement { get; set; }

        internal BaseElement(IWebDriver webDriver, By byLocator)
        {
            _webDriver = webDriver;
            _byLocator = byLocator;
            WebElement = FindElement();
        }

        private IWebElement FindElement()
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_byLocator));
        }

        internal void Click()
        {
            WebElement.Click();
        }

        internal void InputText(string textToInput)
        {
            WebElement.SendKeys(textToInput);
        }

        internal bool IsDisplayed()
        {
            return WebElement.Displayed;
        }
        internal string GetElementText()
        {
            return WebElement.Text;
        }
        internal void ClearText()
        {
            WebElement.Click();
            WebElement.SendKeys(Keys.Control + "a");
            WebElement.SendKeys(Keys.Delete);
        }
    }
}
