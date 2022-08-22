using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace VeeamVacancies.BrowserFactory
{
    public class FirefoxFactory : IBrowserFactory
    {
        private readonly TestSettings _settings;

        public FirefoxFactory(TestSettings settings) => _settings = settings;

        public Browser Name => Browser.Firefox;

        public IWebDriver Create()
        {
            var driverService = FirefoxDriverService.CreateDefaultService();
            var options = new FirefoxOptions();
            if (_settings.Headless)
            {
                options.AddArgument("-headless");
            }
            options.AddArgument("-private");
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("network.cookie.cookieBehavior", 0);
            var driver = new FirefoxDriver(driverService, options);
            driver.Manage().Window.Maximize();
            return driver;
        }
        
    }
}
