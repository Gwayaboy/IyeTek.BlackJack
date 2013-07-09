using IyeTek.BlackJack.TestLibrary.Configuration;
using NUnit.Framework;

namespace IyeTek.BlackJack.ExecutableSpecifications
{
    /// <summary>
    /// This class has methods that run before and after each test run
    /// Configure the generated report for each Executable specification
    /// </summary>
    [SetUpFixture]
    public class ExecutableSpecificationsConfigurator
    {
        [SetUp]
        public void SetUpTestEnvironment()
        {
            BddifyConfiguration.InitializeBddify(new ExecutableSpecificationsHtmlReportConfig());
        }
    }
}