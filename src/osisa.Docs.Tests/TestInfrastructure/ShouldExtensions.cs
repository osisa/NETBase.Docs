using Shouldly;

using Statiq.Common;
using Statiq.Testing;

namespace osisa.Docs.Tests.TestInfrastructure
{
    internal static class ShouldExtensions
    {
        public static void ShouldHaveCodeElements(this BootstrapperTestResult result, int expectedCodeItems, int expectedInputItems)
        {
            result.Outputs["Api"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Archives"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Assets"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Code"][Phase.Input].Length.ShouldBe(expectedCodeItems);
            ////testContext.WriteDocs(result, "Code", Phase.Input);
            result.Outputs["Content"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Data"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["DirectoryMetadata"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Feeds"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Inputs"][Phase.Input].Length.ShouldBe(expectedInputItems);
            ////testContext.WriteDocs(result, "Inputs", Phase.Input);
            result.Outputs["Redirects"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["SearchIndex"][Phase.Input].Length.ShouldBe(0);
            result.Outputs["Sitemap"][Phase.Input].Length.ShouldBe(0);
        }
    }
}