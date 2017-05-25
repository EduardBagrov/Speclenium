using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Speclenium.Pages
{
    class MainPage
    {
        IWebDriver driver;
        public MainPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private readonly By findTextLocator = By.XPath("//input[@id='lst-ib']");
        private readonly By googleLogoLocator = By.XPath("//div[@id='navcnt']");
        private readonly By imagesLocator = By.XPath("//a[@class='q qs']");

        public IWebElement findText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement textbox = wait.Until<IWebElement>(d => d.FindElement(findTextLocator));

            return textbox;
        }

        public IWebElement isGoogleLogoPresent()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement logo = wait.Until<IWebElement>(d => d.FindElement(googleLogoLocator));
            return logo;
        }

        public void clickImagesTab()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement logo = wait.Until<IWebElement>(d => d.FindElement(imagesLocator));
            logo.Click();
        }
    }
}
