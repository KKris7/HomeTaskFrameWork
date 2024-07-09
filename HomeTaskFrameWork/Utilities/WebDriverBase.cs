using OpenQA.Selenium;

namespace HomeTaskFrameWork.Utilities
{
    internal class WebDriverBase
    {
        internal IWebDriver webDriver;

        internal WebDriverBase(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        internal static string TakeScreenshot(IWebDriver driver)
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName;
            string screenshotsPath = Path.Combine(projectDirectory, "Screenshots");

            Directory.CreateDirectory(screenshotsPath);

            string screenshotFileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            string screenshotFilePath = Path.Combine(screenshotsPath, screenshotFileName);

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotFilePath);

            return screenshotFilePath;
        }
    }
}
