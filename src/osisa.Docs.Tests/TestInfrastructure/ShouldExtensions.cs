// --------------------------------------------------------------------------------------------------------------------
// <copyright company="o.s.i.s.a. GmbH" file="ShouldExtensions.cs">
//    (c) 2014. See licence text in binary folder.
// </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Shouldly;

using Statiq.Common;
using Statiq.Testing;

namespace osisa.Docs.Tests.TestInfrastructure
{
    internal static class ShouldExtensions
    {
        #region Public Methods and Operators

        public static void ShouldHaveCodeElements(this BootstrapperTestResult result, int expectedCodeItems, int expectedInputItems)
        {
            result.Outputs["Api"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Archives"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Assets"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Code"][Phase.Input].Length.ShouldBe(expectedCodeItems);
            result.Outputs["Content"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Data"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["DirectoryMetadata"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Feeds"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Inputs"][Phase.Input].Length.ShouldBe(expectedInputItems);
            result.Outputs["Redirects"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["SearchIndex"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Sitemap"][Phase.Input].Length.ShouldBe(0);
        }

        #endregion
    }
}