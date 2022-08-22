using OpenQA.Selenium;

namespace VeeamVacancies.BrowserFactory
{
    public interface IBrowserFactory : IFactory<IWebDriver>
    {
        Browser Name { get; }
    }

    public interface IFactory<out T>
    {
        T Create();
    }
}
