﻿using HomeTaskFrameWork.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace HomeTaskFrameWork.StepDefinitions
{
    [Binding]
    internal class HomePageStepDefinitions
    {
        private readonly HomePage _homePage;
        private readonly IWebDriver _webDriver;

        internal HomePageStepDefinitions(IWebDriver webDriver)
        {
            _homePage = new HomePage(webDriver);
            _webDriver = webDriver;
        }
        [Given(@"The user is on the home page")]
        internal void GivenINavigateToTheHomePage()
        {
            VerifyTheHomePage();
        }

        [Then(@"the navigation menu items should be displayed '(.*)'")]
        internal void ThenTheNavigationMenuItemsShouldBeDisplayed(string menuItems)
        {
            var items = menuItems.Split(',').Select(item => item.Trim()).ToArray();

            foreach (var item in items)
            {
                VerifyMenuItemIsDisplayed(item);
            }
        }

        [Then(@"the items of About menu dropdown should be displayed '(.*)'")]
        internal void ThenTheItemsOfAboutMenuDropdownShouldBeDisplayed(string aboutMenuItems)
        {
            _homePage.NavigationMenuDropDownBy("About").Click();
            var items = aboutMenuItems.Split(',').Select(item => item.Trim()).ToArray();
            foreach (var item in items)
            {
                Assert.That(_homePage.ElementFromDropDownBy(item).IsDisplayed(), $"{item} dropdown item is not displayed.");
            }
        }


        [Then(@"the footer section should be present")]
        internal void ThenTheFooterLinksShouldBeDisplayed()
        {
            Assert.That(_homePage.FooterSection.IsDisplayed(), "Footer section is not present.");

        }

        [Then(@"it should contain the social media links")]
        internal void ThenItShouldContainTheSocialMediaLinks()
        {
            Assert.That(_homePage.AreSocialMediaLinksPresent(), "Social media links are not present in the footer section.");
        }

        [Then(@"the home page should load within '(.*)' seconds")]
        internal void ThenTheHomePageShouldLoadWithinSeconds(int seconds)
        {
            var loadTime = (long)((IJavaScriptExecutor)_webDriver).ExecuteScript(
                "return performance.timing.loadEventEnd - performance.timing.navigationStart");
            Assert.That(loadTime, Is.LessThanOrEqualTo(seconds * 1000), $"Home page did not load within {seconds} seconds.");
        }

        [When(@"The user enter a '(.*)' in the search input field")]
        internal void WhenIEnterAInTheSearchInputField(string searchText)
        {
            _homePage.SearchButton.Click();
            _homePage.SearchInput.InputText(searchText);
        }

        [When(@"The user press Enter")]
        internal void WhenIPressEnter()
        {
            Actions actions = new Actions(_webDriver);
            actions.SendKeys(Keys.Enter).Perform();
        }

        [Then(@"the search results page should display '(.*)' results")]
        internal void ThenTheSearchResultsPageShouldDisplayRelevantResults(string searchWord)
        {
            Assert.Multiple(() =>
            {
                Assert.That(_webDriver.Title, Is.EqualTo($"{searchWord} - Strypes"));
                Assert.That(_homePage.TitleBy($"Results for: {searchWord}").IsDisplayed());

                if (searchWord == "no resultt")
                {
                    Assert.That(_homePage.SearchResults.Count, Is.EqualTo(0), $"Expected no results for '{searchWord}', but some results were found.");
                }
                else
                {
                    Assert.That(_homePage.SearchResults.Count, Is.GreaterThan(0), $"Expected results for '{searchWord}', but none were found.");
                }
            });
        }

        [When(@"The user navigates to the '(.*)' page")]
        internal void WhenINavigateToTheSection(string page)
        {
            _homePage.NavigationMenuItemsBy(page).Click();
        }

        [When(@"The user switches to the last opened tab")]
        internal void SwitchToTheLastOpenedTab()
        {
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles.Last());
        }

        private void VerifyTheHomePage()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_webDriver.Url, Is.EqualTo("https://strypes.eu/"), "Unexpected URL.");
                Assert.That(_webDriver.Title, Is.EqualTo("Strypes | End-to-end software solutions"), "Unexpected title.");
                Assert.That(_homePage.Logo.IsDisplayed(), "Logo is not displayed on the homepage");
            });
        }
        private void VerifyMenuItemIsDisplayed(string item)
        {
            switch (item)
            {
                case "About":
                case "Services":
                case "Resources":
                    Assert.That(_homePage.NavigationMenuDropDownBy(item).IsDisplayed(), $"{item} should be displayed in the main menu");
                    break;
                case "Customers":
                case "Nearsurance":
                case "Careers":
                    Assert.That(_homePage.NavigationMenuItemsBy(item).IsDisplayed(), $"{item} should be displayed in the main menu");
                    break;
                default:
                    throw new ArgumentException($"Unexpected menu item '{item}' encountered. Please check the item.");
            }
        }
    }
}
