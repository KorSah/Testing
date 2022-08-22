using OpenQA.Selenium;

namespace VeeamVacancies.PageObjects
{
    public class VacanciesPage
    {
        private readonly IWebDriver _driver;
        private TestSettings _settings;
        private readonly Dictionary<string, string> Languages = new()
        {
            { "lang-option-0", "English"},
            { "lang-option-1", "Russian"},
            { "lang-option-2", "French"},
            { "lang-option-3", "German"},
        };

        private IWebElement DepartmentsElement
            => _driver.FindElements(By.Id("sl"))
            .FirstOrDefault(e => e.Text.Contains("All departments"));


        //private IWebElement LanguagesElement => _driver.FindElements(By.Id("sl"))
        //    .FirstOrDefault(e => e.Text.Contains("All languages"));

        private IWebElement OpenVacanciesCount => _driver.FindElement(By.XPath("//span[@class = 'text-secondary pl-2']"));

        public string Title => _driver.Title;
        public string Source => _driver.PageSource;

        public VacanciesPage(IWebDriver driver, TestSettings settings) 
        {
            _driver = driver;
            _settings = settings;
        }

        public void Navigate() => _driver.Navigate().GoToUrl(_settings.VacancyUrl);

        public void ChooseDepartment(string value)
        {
            DepartmentsElement.Click();
            _driver.FindElement(By.LinkText(value)).Click();
        }
        
        public void ChooseLanguage(string[] languages)
        {
            GetLanguage().Click();
            for (int i = 0; i < languages.Length; i++)
            {
                var lang = Languages.Where(item => item.Value == languages[i]).FirstOrDefault().Key;
                
                _driver.FindElement(By.Id(lang)).Click();
            }
            var searchValue = String.Join(", ", languages);
            GetLanguage(searchValue).Click();
        }
        
        public string GetOpenVacancies()
        {
            return OpenVacanciesCount.GetAttribute("innerHTML");
        }

        private IWebElement GetLanguage(string language = "All languages")
        {
            return _driver.FindElements(By.Id("sl"))
            .FirstOrDefault(e => e.Text.Contains(language));
        }
    }
}
