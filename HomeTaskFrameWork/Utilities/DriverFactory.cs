using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeTaskFrameWork.Utilities
{
    internal class DriverFactory
    {
        private IWebDriver _driver;
        internal DriverFactory(BrowserName browserName)
        {
            switch (browserName)
            {
                case BrowserName.Chrome:
                    _driver = CreateChromeDriver();
                    break;
                default:
                    throw new ArgumentException("Invalid browser has been selected. Missing implementation?");
            }

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public IWebDriver WebDriver()
        {
            if (_driver == null)
            {
                throw new NullReferenceException("The WebDriver browser instance was not initialized or was closed.");
            }
            return _driver;
        }

        private IWebDriver CreateChromeDriver()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string driverDirectory = baseDirectory.Replace(@"\bin\Debug\net8.0", @"\Drivers");
            var options = new ChromeOptions();
            return new ChromeDriver(driverDirectory, options);
        }

        internal void CloseAllDrivers()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
