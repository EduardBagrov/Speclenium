using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Speclenium.Utils;
using Speclenium.Pages;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Speclenium
{
    [Binding]
    public sealed class SearchSteps
    {
        IWebDriver driver;
        MainPage mainPage;

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }

        [Given(@"I have opened a chrome web browser with ""(.*)"" url")]
        public void GivenIHaveOpenedAChromeWebBrowserWithUrl(string url)
        {
            driver = WebDriverFactory.GetDriver("chrome");
            driver.Navigate().GoToUrl(url);
            mainPage = new MainPage(driver);
        }

        [When(@"I type ""(.*)"" in the search field")]
        public void WhenITypeInTheSearchField(string textToSearch)
        {
            var inputElement = mainPage.findText();
            Assert.NotNull(inputElement);

            inputElement.SendKeys(textToSearch);
            inputElement.SendKeys(Keys.Return);
        }

        [Then(@"I should see search results")]
        public void ThenIShouldSeeSearchResults()
        {
            var logo = mainPage.isGoogleLogoPresent();
            Assert.IsNotNull(logo);
        }

        [When(@"I click Images")]
        public void WhenIClickImages()
        {
            mainPage.clickImagesTab();
        }

        [When(@"I navigate back")]
        public void WhenINavigateBack()
        {
            driver.Navigate().Back();
        }

    }
}
