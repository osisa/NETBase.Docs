// --------------------------------------------------------------------------------------------------------------------
// <copyright company="o.s.i.s.a. GmbH" file="TestValues.cs">
//    (c) 2014. See licence text in binary folder.
// </copyright>
//  --------------------------------------------------------------------------------------------------------------------

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
        #region Constants

        //public const string TestPath = @"c:\TestBin\";
        public const string TestPath = @"C:\repos\NETBase.Docs\TestData\TestBin\";

        public const int ExpectedInputItemsCount = 14;

        #endregion

        #region Public Methods and Operators

        public static void WriteDocuments(this TestContext @this, BootstrapperTestResult testResult, string pipelineName = "Code", Phase phase = Phase.Input)
        {
            @this.WriteLine("Documents:\r\n{0}", testResult.Outputs[pipelineName][phase].ListToString(m => m.ToDisplayString(), SpecialCharacterConstants.CRLF));
        }

        public static void WriteLogs(this TestContext @this, BootstrapperTestResult testResult)
        {
            @this.WriteLine("LogMessages:\r\n{0}", testResult.LogMessages.ListToString(m => m.FormattedMessage, SpecialCharacterConstants.CRLF));
        }

        #endregion
    }
}