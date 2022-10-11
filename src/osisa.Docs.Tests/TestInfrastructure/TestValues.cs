using Microsoft.VisualStudio.TestTools.UnitTesting;

using osisa.Ensure;

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
            @this.WriteLine("LogMessages:{0}\r\n", testResult.LogMessages.ListToString(m => m.FormattedMessage, SpecialCharacterConstants.CRLF));
        }
    }
}