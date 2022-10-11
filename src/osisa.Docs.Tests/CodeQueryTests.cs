using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using osisa.Ensure;

using Shouldly;

using Statiq.App;
using Statiq.Common;
using Statiq.Core;
using Statiq.Testing;

using static osisa.Docs.Tests.TestInfrastructure.TestValues;

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace osisa.Docs.Tests
#pragma warning restore SA1300 // Element should begin with upper-case letter
{
    [TestClass]
    public class CodeQueryTests
    {
        // ReSharper disable once UnusedMember.Global
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public TestContext TestContext { get; set; }

        [TestMethod]
        public async Task RunTestAsyncShouldReturnFileSystemWithDefaultPathAsync()
        {
            // Arrange
            Bootstrapper bootstrapper = Bootstrapper
                .Factory
                .Create(Array.Empty<string>())
                .SetRootPath(TestPath);

            // Act
            BootstrapperTestResult result = await bootstrapper.RunTestAsync();

            // Assert
            TestContext.WriteLine(result.LogMessages.ToArray().ListToString(t => t.FormattedMessage, SpecialCharacterConstants.CRLF));
            result.ExitCode.ShouldBe((int)ExitCode.Normal);

            TestContext.WriteLine("Output:{0}\r\n", result.Outputs.ToArray().ListToString(t => t.Value.EnsureToString(), SpecialCharacterConstants.CRLF));
            result.Outputs.Count.ShouldBe(0);

            bootstrapper.FileSystem.ShouldNotBeNull();
            TestContext.WriteLine("Files: {0}", bootstrapper.FileSystem.RootPath);
            bootstrapper.FileSystem.RootPath.ShouldBe(TestPath);
            TestContext.WriteLine("Output: {0}", bootstrapper.FileSystem.OutputPath);
        }

        [TestMethod]
        public async Task RunAsyncShouldReturnExitCodeNormalAsync()
        {
            // Arrange
            Bootstrapper bootstrapper = Bootstrapper
                .Factory
                .CreateDefault(Array.Empty<string>())
                .BuildPipeline("test", pipeline => pipeline
                    .WithInputModules(new ReadFiles("**/*.*"))
                    .WithProcessModules(new WriteFiles()))
                    ////.WithOutputModules(new WriteFiles()))
                .SetRootPath(TestPath);

            // Act
            int result = await bootstrapper.RunAsync();

            // Assert
            result.ShouldBe((int)ExitCode.Normal);
        }

        [TestMethod]
        public async Task RunTestAsyncTestPipeLineShouldReturnOneInputDocumentAsync()
        {
            // Arrange
            Bootstrapper bootstrapper = Bootstrapper
                .Factory
                .CreateDefault(Array.Empty<string>())
                .BuildPipeline("test", pipeline => pipeline
                    .WithInputModules(new ReadFiles("**/*.*"))
                    .WithProcessModules(new WriteFiles()))
                .SetRootPath(TestPath);

            // Act
            BootstrapperTestResult result = await bootstrapper.RunTestAsync();

            // Assert
            result.Outputs.Count.ShouldBe(1);
            result.Outputs.First().Key.ShouldBe("test");
            Dictionary<Phase, ImmutableArray<IDocument>> dictionary = result.Outputs.First().Value;
            dictionary.Count.ShouldBe(4);
            IDocument[] inDocuments = dictionary[Phase.Input].ToArray();
            inDocuments.Length.ShouldBe(1);
            inDocuments[0].Source.FullPath.ShouldEndWith("index.md");
            TestContext.WriteLogs(result);
        }

        [TestMethod]
        public async Task CollectShouldNotReturnNullAsync()
        {
            // Arrange

            // Act
            BootstrapperTestResult result = await Bootstrapper
                .Factory
                .CreateDefault(Array.Empty<string>())
                .BuildPipeline("collect", builder => builder.WithInputModules(new ReadFiles("*.*")))
                .RunTestAsync();

            // Assert
            result.ShouldNotBeNull();
        }
    }
}

////[TestMethod]
////public async Task GetCodeFiles2Async()
////{
////    // Arrange
////    Bootstrapper xx = Bootstrapper.Factory.Create(Array.Empty<string>()).SetRootPath(@"c:\TestBin");
////    IExecutionContext ctx = new Mock<IExecutionContext>().Object;
////    AnalyzeCSharp analyzer = new AnalyzeCSharp()
////        .WhereNamespaces(ctx.Settings.GetBool(DocsKeys.IncludeGlobalNamespace))
////        .WherePublic()
////        .WithCssClasses("code", "cs")
////        .WithDestinationPrefix(ctx.GetPath(DocsKeys.ApiPath))
////        .WithAssemblies(Config.FromContext<IEnumerable<string>>(ctx => ctx.GetList<string>(DocsKeys.AssemblyFiles)))
////        .WithProjects(Config.FromContext<IEnumerable<string>>(ctx => ctx.GetList<string>(DocsKeys.ProjectFiles)))
////        .WithSolutions(Config.FromContext<IEnumerable<string>>(ctx => ctx.GetList<string>(DocsKeys.SolutionFiles)))
////        .WithAssemblySymbols()
////        .WithImplicitInheritDoc(ctx.GetBool(DocsKeys.ImplicitInheritDoc));

////    // Act
////    IEnumerable<IDocument> result1 = await analyzer.ExecuteAsync(ctx);
////    IDocument[] result = result1.ToArray();

////    // Assert
////    result.ShouldNotBeNull();
////    result.Length.ShouldBe(1);
////}

////[TestMethod]
////public async Task MethodNamAsync()
////{
////    // Arrange
////    BootstrapperTestResult xx = await Bootstrapper
////        .Factory
////        .CreateDocs(Array.Empty<string>())
////        .SetRootPath(@"C:/docgen")
////        .AddSetting("SourceFiles", "src/osisa.Project/**/*.cs")
////        .RunTestAsync();

////    // Act
////    // Assert
////}
