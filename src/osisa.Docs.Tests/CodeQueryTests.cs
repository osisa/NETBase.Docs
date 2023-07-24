// --------------------------------------------------------------------------------------------------------------------
// <copyright company="o.s.i.s.a. GmbH" file="CodeQueryTests.cs">
//    (c) 2014. See licence text in binary folder.
// </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using osisa.Docs.Tests.TestInfrastructure;
using osisa.Ensure;
using osisa.TestInfrastructure.UnitTestSupport;

using Shouldly;

using Statiq.App;
using Statiq.Common;
using Statiq.Core;
using Statiq.Docs;
using Statiq.Testing;

using static osisa.Docs.Tests.TestInfrastructure.TestValues;

namespace osisa.Docs.Tests
{
    /// <summary>   (Unit Test Class) a code query tests. </summary>
    [TestClass]
    public class CodeQueryTests : UnitTestsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// (Unit Test Method) adds project files should return one input document asynchronous.
        /// </summary>
        /// <returns>   A Task. </returns>
        [TestMethod]
        public async Task AddProjectFiles_ShouldReturn1CodeItemAnd9InputItemsAsync()
        {
            // Arrange
            ////"../src/**/{!.git,!bin,!obj,!packages,!*.Tests,}/**/*.cs",
            Bootstrapper bootstrapper = Bootstrapper
                .Factory
                .CreateDocs(Array.Empty<string>())
                ////.AddSetting("SourceFiles", "../src/**/{!.git,!bin,!obj,!packages,!*.Tests,}/**/*Project*.cs")
                .SetRootPath(TestPath)
                ////.AddSetting("SourceFiles", "../src/**/{!.git,!bin,!obj,!packages,!*.Tests,}/**/*.cs");
                .AddSetting("SourceFiles", "../src/**/TestCoreClassLibrary.csproj")
                .AddProjectFiles("../src/**/TestCoreClassLibrary.csproj");

            // Act
            BootstrapperTestResult result = await bootstrapper.RunTestAsync();

            // Assert
            TestContext.WriteLogs(result);
            TestContext.WriteDocuments(result);

            result.ShouldHaveCodeElements(1, ExpectedInputItemsCount);
            result.Outputs.Count.ShouldBe(12);
        }

        /// <summary>
        /// (Unit Test Method) adds project files should return one input document asynchronous.
        /// </summary>
        /// <returns>   A Task. </returns>
        [TestMethod]
        public async Task AddSolutionFiles_ShouldReturn1CodeItemAnd9InputItemsAsync()
        {
            // Arrange
            ////"../src/**/{!.git,!bin,!obj,!packages,!*.Tests,}/**/*.cs",
            Bootstrapper bootstrapper = Bootstrapper
                .Factory
                .CreateDocs(Array.Empty<string>())
                ////.AddSetting("SourceFiles", "../src/**/{!.git,!bin,!obj,!packages,!*.Tests,}/**/*Project*.cs")
                .SetRootPath(TestPath)
                ////.AddSetting("SourceFiles", "../src/**/{!.git,!bin,!obj,!packages,!*.Tests,}/**/*.cs");
                .AddSetting("SourceFiles", "../src/TestSolution.sln")
                .AddProjectFiles("../src/TestSolution.sln");

            // Act
            BootstrapperTestResult result = await bootstrapper.RunTestAsync();

            // Assert
            TestContext.WriteLogs(result);
            TestContext.WriteDocuments(result);

            result.ShouldHaveCodeElements(1, ExpectedInputItemsCount);
            result.Outputs.Count.ShouldBe(12);
        }

        /// <summary>   (Unit Test Method) collect should not return null asynchronous. </summary>
        /// <returns>   A Task. </returns>
        [TestMethod]
        public async Task Collect_ShouldNotReturnNullAsync()
        {
            // Act
            BootstrapperTestResult result = await Bootstrapper
                .Factory
                .CreateDefault(Array.Empty<string>())
                .BuildPipeline("collect", builder => builder.WithInputModules(new ReadFiles("*.*")))
                .RunTestAsync();

            // Assert
            result.ShouldNotBeNull();
        }

        /// <summary>
        /// (Unit Test Method) executes the '1 test asynchronous test pipe line should return one input
        /// document asynchronous' operation.
        /// </summary>
        /// <returns>   A Task. </returns>
        [TestMethod]
        public async Task DefaultCodeItems_ShouldReturn4CodeItemAnd9InputItemsAsync()
        {
            // Arrange
            Bootstrapper bootstrapper = Bootstrapper
                .Factory
                .CreateDocs(Array.Empty<string>())
                .SetRootPath(TestPath);

            // Act
            BootstrapperTestResult result = await bootstrapper.RunTestAsync();

            // Assert
            TestContext.WriteLogs(result);
            TestContext.WriteDocuments(result);

            result.ShouldHaveCodeElements(4, ExpectedInputItemsCount);
            result.Outputs.Count.ShouldBe(12);
        }

        /// <summary>
        /// (Unit Test Method) executes the 'asynchronous should return exit code normal asynchronous'
        /// operation.
        /// </summary>
        /// <returns>   A Task. </returns>
        [TestMethod]
        public async Task BuildPipeline_Test_ShouldReturnExitCodeNormalAsync()
        {
            // Arrange
            Bootstrapper bootstrapper = Bootstrapper
                .Factory
                .CreateDefault(Array.Empty<string>())
                .BuildPipeline(
                    "test",
                    pipeline => pipeline
                        .WithInputModules(new ReadFiles("**/*.*"))
                        .WithProcessModules(new WriteFiles()))
                ////.WithOutputModules(new WriteFiles()))
                .SetRootPath(TestPath);

            // Act
            int result = await bootstrapper.RunAsync();

            // Assert
            result.ShouldBe((int)ExitCode.Normal);
        }

        /// <summary>
        /// (Unit Test Method) executes the 'test asynchronous should return file system with default
        /// path asynchronous' operation.
        /// </summary>
        /// <returns>   A Task. </returns>
        [TestMethod]
        public async Task RunTestAsync_ShouldReturnFileSystemWithDefaultPathAsync()
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

        /// <summary>
        /// (Unit Test Method) executes the 'test asynchronous should return 3 code items and 9 input
        /// items asynchronous' operation.
        /// </summary>
        /// <returns>   A Task. </returns>
        [TestMethod]
        public async Task RunTestAsync_ShouldReturn3CodeItemsAnd9InputItemsAsync()
        {
            // Arrange
            ////"../src/**/{!.git,!bin,!obj,!packages,!*.Tests,}/**/*.cs",
            Bootstrapper bootstrapper = Bootstrapper
                .Factory
                .CreateDocs(Array.Empty<string>())
                .SetRootPath(TestPath)
                .AddSetting("SourceFiles", "../src/**/{!.git,!bin,!obj,!packages,!*.Tests,}/**/*Project*.cs");

            // Act
            BootstrapperTestResult result = await bootstrapper.RunTestAsync();

            // Assert
            TestContext.WriteLogs(result);
            TestContext.WriteDocuments(result);

            result.ShouldHaveCodeElements(3, ExpectedInputItemsCount);
            result.Outputs.Count.ShouldBe(12);
        }

        /// <summary>
        /// (Unit Test Method) executes the 'test asynchronous test pipe line should return one input
        /// document asynchronous' operation.
        /// </summary>
        /// <returns>   A Task. </returns>
        [TestMethod]
        public async Task RunTestAsync_TestPipeLine_ShouldReturnOneOutputAsync()
        {
            // Arrange
            Bootstrapper bootstrapper = Bootstrapper
                .Factory
                .CreateDefault(Array.Empty<string>())
                .BuildPipeline(
                    "test",
                    pipeline => pipeline
                        .WithInputModules(new ReadFiles("**/*.*"))
                        .WithProcessModules(new WriteFiles()))
                .SetRootPath(TestPath);

            // Act
            BootstrapperTestResult result = await bootstrapper.RunTestAsync();

            // Assert
            TestContext.WriteLogs(result);
            
            result.Outputs.Count.ShouldBe(1);
            result.Outputs.First().Key.ShouldBe("test");
            Dictionary<Phase, ImmutableArray<IDocument>> dictionary = result.Outputs.First().Value;
            dictionary.Count.ShouldBe(4);
            IDocument[] inDocuments = dictionary[Phase.Input].ToArray();
            inDocuments.Length.ShouldBe(0);
        }

        #endregion
    }
}