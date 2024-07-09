using BoDi;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using HomeTaskFrameWork.Utilities;

namespace HomeTaskFrameWork.Hooks
{
    [Binding]
    public class Hooks
    {
        private IWebDriver webDriver;
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            webDriver = new DriverFactory(BrowserName.Chrome).WebDriver();
            _container.RegisterInstanceAs(webDriver);
            webDriver.Navigate().GoToUrl("https://strypes.eu");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            webDriver = _container.Resolve<IWebDriver>();

            if (TestContext.CurrentContext?.Result?.Outcome != ResultState.Success)
            {
                var screenshotPath = WebDriverBase.TakeScreenshot(webDriver);
                Console.WriteLine($"SCREENSHOT[ file:///{screenshotPath.Replace("\\", "/").Replace(" ", "%20")} ]SCREENSHOT");
            }

            if (webDriver != null)
            {
                webDriver.Quit();
                webDriver.Dispose();
            }
        }
    }
}
