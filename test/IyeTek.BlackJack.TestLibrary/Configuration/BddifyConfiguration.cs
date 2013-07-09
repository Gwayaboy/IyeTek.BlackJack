using TestStack.BDDfy.Configuration;
using TestStack.BDDfy.Processors.HtmlReporter;

namespace IyeTek.BlackJack.TestLibrary.Configuration
{
    public static class BddifyConfiguration
    {
        public static void InitializeBddify(DefaultHtmlReportConfiguration reportConfiguration)
        {
            Configurator.Scanners.StoryMetaDataScanner = () => new SpecStoryMetaDataScanner();
            Configurator.BatchProcessors.HtmlReport.Disable();
            Configurator.BatchProcessors.Add(new HtmlReporter(reportConfiguration));
        }
    }
}