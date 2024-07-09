using HomeTaskFrameWork.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace HomeTaskFrameWork.Pages
{
    internal class BasePage : WebDriverBase
    {
        private readonly IWebDriver _webDriver;

        internal BasePage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        /* Locators */
        private By _logo = By.XPath("//a[@href='https://strypes.eu/']");
        private By _navigationMenuItemsBy(string label) => By.XPath($"//a[@class='elementor-item menu-link'][normalize-space()='{label}']");
        private By _navigationMenuDropDownBy(string label) => By.XPath($"//a[@class='elementor-item menu-link has-submenu'][normalize-space()='{label}']");
        private By _footerSection => By.XPath("//footer[@data-id='ec24f16']");
        private By _socialMediaLinksBy(string link) => By.CssSelector($"a[href='{link}']");
        private By _searchButton => By.XPath("//*[@id=\"header_pop\"]/div/div/div/section[1]/div/div[2]");
        private By _searchInput => By.CssSelector("#elementor-search-form-5295a54a");
        private By _titleBy(string text) => By.XPath($"//h2[normalize-space()='{text}']");
        private By _searchResults => By.CssSelector("div[class='elementor-posts-container elementor-posts elementor-posts--skin-classic elementor-grid'] article");
        private By _elementFromDropDownBy(string text) => By.XPath($"//ul[@aria-hidden='false']//a[normalize-space()='{text}']");

        /* Elements */
        internal BaseElement Logo => new BaseElement(_webDriver, _logo);
        internal BaseElement NavigationMenuItemsBy(string label) => new BaseElement(_webDriver, _navigationMenuItemsBy(label));
        internal BaseElement NavigationMenuDropDownBy(string label) => new BaseElement(_webDriver, _navigationMenuDropDownBy(label));
        internal BaseElement ElementFromDropDownBy(string text) => new BaseElement(_webDriver, _elementFromDropDownBy(text));
        internal BaseElement FooterSection => new BaseElement(_webDriver, _footerSection);
        internal BaseElement SocialMediaLinksBy(string link) => new BaseElement(_webDriver, _socialMediaLinksBy(link));
        internal BaseElement SearchButton => new BaseElement(_webDriver, _searchButton);
        internal BaseElement SearchInput => new BaseElement(_webDriver, _searchInput);
        internal List<IWebElement> SearchResults => _webDriver.FindElements(_searchResults).ToList();
        internal BaseElement TitleBy(string text) => new BaseElement(_webDriver, _titleBy(text));

        /* Methods */
        internal bool AreSocialMediaLinksPresent()
        {
            List<string> socialMediaLinks = new List<string>
            {
                "https://twitter.com/strypesICT",
                "https://www.linkedin.com/company/strypes/",
                "https://www.youtube.com/channel/UC_bZ_Mu0G0OdQhcpsHq7w-w",
                "https://www.instagram.com/strypes.group/",
                "https://www.facebook.com/StrypesBulgaria/"
            };
            Actions actions = new Actions(_webDriver);
            actions.MoveToElement(FooterSection.WebElement).Perform();

            return socialMediaLinks.All(link => SocialMediaLinksBy(link).IsDisplayed());
        }
    }
}