using Microsoft.Extensions.Configuration;

namespace VeeamVacancies
{
    public class Configuration
    {
        private TestSettings _setting;

        public Configuration()
        {
            _setting = GetAppSettings();
        }

        public TestSettings GetAppSettings()
        {
            var builder = new ConfigurationBuilder()
                      .AddJsonFile("testSettings.json", optional: false);

            IConfiguration config = builder.Build();

            return config.GetRequiredSection(nameof(TestSettings)).Get<TestSettings>();
        }
    }
}
