using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace GeocitizenTest.Framework.Helpers
{
    public class ReportHelper
    {
        private AventStack.ExtentReports.ExtentReports _extent;
        private ExtentTest _test;

        private static readonly Lazy<ReportHelper> _lazy =
            new Lazy<ReportHelper>(() => new ReportHelper());

        public static ReportHelper Instance => _lazy.Value;

        private ReportHelper()
        {
            _extent = new AventStack.ExtentReports.ExtentReports();
            var reporter = new ExtentHtmlReporter($"report-{DateTime.Now}.html");
            _extent.AttachReporter(reporter);
        }

        public void Initialize()
        {
            var context = TestContext.CurrentContext;
            if (context.Test.Properties["Description"].Any())
            {
                var description = context.Test.Properties["Description"].First().ToString();
                _test = _extent.CreateTest(context.Test.Name, description);
            }
            else
            {
                _test = _extent.CreateTest(context.Test.Name);
            }
            foreach(var category in context.Test.Properties["Category"])
            {
                _test.AssignCategory(category.ToString());
            }
        }

        public void FinalizeReport()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            Status testStatus;

            switch(status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    testStatus = Status.Fail;
                    _test.Log(testStatus, TestContext.CurrentContext.Result.Message);
                    _test.Log(testStatus, TestContext.CurrentContext.Result.StackTrace);
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Inconclusive:
                    testStatus = Status.Warning;
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    testStatus = Status.Skip;
                    break;
                default:
                    testStatus = Status.Pass;
                    break;
            }

            _test.Log(testStatus, $"Test ended with {testStatus}");
            _extent.Flush();
        }

        public void Info(string text) => _test.Log(Status.Info, text);
    }
}
