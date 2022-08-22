using OpenQA.Selenium;
using VeeamVacancies;
using VeeamVacancies.BrowserFactory;
using VeeamVacancies.PageObjects;

namespace Veeam.Test
{
    public class Tests
    {
        private IWebDriver _driver;
        private TestSettings _settings;
        private Configuration _configuration;
        
        [SetUp]
        public void Setup()
        {
            _configuration = new Configuration();
            _settings = _configuration.GetAppSettings();
            _driver = new ChromeFactory(_settings).Create();
        }

        [Test]
        public void FindVacanciesTest()
        {
            int expectedValue = 67;
            var vacancyPage = new VacanciesPage(_driver, _settings);
            vacancyPage.Navigate();
            vacancyPage.ChooseDepartment("Research & Development");
            vacancyPage.ChooseLanguage(new string[] { "English" });
            string val = vacancyPage.GetOpenVacancies();
            Assert.That(expectedValue, Is.EqualTo(int.Parse(val)));
        }

        //[TearDown]
        //public void CleanUp()
        //{
        //    _driver?.Close();
        //    _driver?.Quit();
        //}
    }
}