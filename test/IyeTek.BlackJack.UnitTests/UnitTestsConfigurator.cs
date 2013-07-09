using IyeTek.BlackJack.TestLibrary.Configuration;
using NUnit.Framework;

namespace IyeTek.BlackJack.UnitTests
{
    /// <summary>
    /// This class has methods that run before and after each test run
    /// It configures the BDDify report engine
    /// </summary>
    [SetUpFixture]
    public class UnitTestsConfigurator
    {
        [SetUp]
        public void SetUpTestEnvironment()
        {
            BddifyConfiguration.InitializeBddify(new UnitTestsSpecificationsHtmlReportConfig());
        }

        
    }
}