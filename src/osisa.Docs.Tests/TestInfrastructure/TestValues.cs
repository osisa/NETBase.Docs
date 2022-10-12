using Microsoft.VisualStudio.TestTools.UnitTesting;

using osisa.Ensure;

using Statiq.Common;
using Statiq.Testing;

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace osisa.Docs.Tests.TestInfrastructure
#pragma warning restore SA1300 // Element should begin with upper-case letter
{
    internal static class TestValues
    {
        public const string TestPath = @"c:\TestBin\";

        public static void WriteLogs(this TestContext @this, BootstrapperTestResult testResult)
        {
            @this.WriteLine("LogMessages:\r\n{0}", testResult.LogMessages.ListToString(m => m.FormattedMessage, SpecialCharacterConstants.CRLF));
        }

        public static void WriteDocuments(this TestContext @this, BootstrapperTestResult testResult, string pipelineName = "Code", Phase phase = Phase.Input)
        {
            @this.WriteLine("Documents:\r\n{0}", testResult.Outputs[pipelineName][phase].ListToString(m => m.ToDisplayString(), SpecialCharacterConstants.CRLF));
        }
    }
}