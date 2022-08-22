using System.Diagnostics.CodeAnalysis;

namespace VeeamVacancies
{
    public class TestSettings
    {
        public Browser Browser { get; set; }
        public bool Headless { get; set; }
        public uint DefaultTimeoutSeconds { get; set; }
        public string VacancyUrl { get; set; }
    }
}
