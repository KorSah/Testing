using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VeeamVacancies.BrowserFactory
{
    public class ChromeFactory : IBrowserFactory
    {
        private readonly TestSettings _settings;
        
        public ChromeFactory(TestSettings settings) => _settings = settings;

        public Browser Name => Browser.Chrome;

        public IWebDriver Create()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();
            if (_settings.Headless)
            {
                options.AddArgument("headless");
            }
            options.AddArgument("--no-sandbox");
            options.AddArgument("--start-maximized");
            options.AddUserProfilePreference("profile.cookie_controls_mode", 0);
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            return new ChromeDriver(driverService, options, TimeSpan.FromSeconds(_settings.DefaultTimeoutSeconds));
            //return new ChromeDriver(driverService, options);
        }
    }
}
