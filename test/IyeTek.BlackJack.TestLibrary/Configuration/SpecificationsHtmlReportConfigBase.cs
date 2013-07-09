using System.Linq;
using Humanizer;
using TestStack.BDDfy.Processors.HtmlReporter;

namespace IyeTek.BlackJack.TestLibrary.Configuration
{
    public class SpecificationsHtmlReportConfigBase : DefaultHtmlReportConfiguration
    {
        protected string ProjectName { get { return GetType().Assembly.GetName().Name.Split('.').Last(); } }
        protected virtual string ReportDirectoryName { get { return @"..\..\Report"; } }

        public override string OutputFileName
        {
            get
            {
                var reportFileName = ProjectName + ".html";
                return reportFileName;
            }
        }

        public override string OutputPath
        {
            get
            {
                return ReportDirectoryName;
            }
        }

        public override string ReportHeader
        {
            get
            {
                return "IyeTek - Black Jack Card Game";
            }
        }

        public override string ReportDescription
        {
            get
            {
                return ProjectName.Humanize(LetterCasing.Title);
            }
        }
    }
}