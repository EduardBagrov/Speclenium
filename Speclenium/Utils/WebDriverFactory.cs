using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Speclenium.Utils
{
    public class WebDriverFactory
    {
        /// <summary>
        ///     Creates instance of needed driver
        /// </summary>
        /// <param name="browser">"IE" for Internet Explorer driver, "Firefox" for Firefox driver, "Chrome" for Chrome driver</param>
        /// <returns></returns>
        public static IWebDriver GetDriver(string browser)
        {
            IWebDriver driver;
            switch (browser)
            {
                case BrowserType.IE:
                    driver = CreateIEDriver();
                    break;
                case BrowserType.Chrome:
                    driver = CreateChromeDriver();
                    break;
                case BrowserType.Firefox:
                    driver = CreateFirefoxDriver();
                    break;
                default:
                    driver = CreateFirefoxDriver();
                    break;
            }

            return driver;
        }


        private static IWebDriver CreateIEDriver()
        {
            return new InternetExplorerDriver(new InternetExplorerOptions
            {
                EnsureCleanSession = false,
                IgnoreZoomLevel = true,
                EnablePersistentHover = true,
                EnableNativeEvents = false,
                RequireWindowFocus = true,
                PageLoadStrategy = InternetExplorerPageLoadStrategy.Eager
            });
        }

        private static void CloseWebDrivers(string type)
        {
            foreach (var process in Process.GetProcessesByName(type))
            {
                if (!process.CloseMainWindow())
                {
                    try
                    {
                        Thread.Sleep(500);
                        process.Kill();
                    }
                    catch
                    {

                    }

                }
            }
        }

        private static IWebDriver CreateFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
        
        private static IWebDriver CreateChromeDriver()
        {
            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(driverService, options);
            return driver;
        }
    }
}
