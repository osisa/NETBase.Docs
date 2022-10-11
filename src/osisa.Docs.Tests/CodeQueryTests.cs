using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Shouldly;

using Statiq.App;
using Statiq.CodeAnalysis;
using Statiq.Common;
using Statiq.Core;
using Statiq.Docs;
using Statiq.Testing;

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace osisa.Docs.Tests
#pragma warning restore SA1300 // Element should begin with upper-case letter
{
    [TestClass]
    public class CodeQueryTests
    {
        [TestMethod]
        public void GetCodeFiles()
        {
            // Arrange
            IExecutionContext ctx = new Mock<IExecutionContext>().Object;

            // Act
            AnalyzeCSharp result = new AnalyzeCSharp()
                .WhereNamespaces(ctx.Settings.GetBool(DocsKeys.IncludeGlobalNamespace))
                .WherePublic()
                .WithCssClasses("code", "cs")
                .WithDestinationPrefix(ctx.GetPath(DocsKeys.ApiPath))
                .WithAssemblies(Config.FromContext<IEnumerable<string>>(ctx => ctx.GetList<string>(DocsKeys.AssemblyFiles)))
                .WithProjects(Config.FromContext<IEnumerable<string>>(ctx => ctx.GetList<string>(DocsKeys.ProjectFiles)))
                .WithSolutions(Config.FromContext<IEnumerable<string>>(ctx => ctx.GetList<string>(DocsKeys.SolutionFiles)))
                .WithAssemblySymbols()
                .WithImplicitInheritDoc(ctx.GetBool(DocsKeys.ImplicitInheritDoc));

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public async Task MethodNamAsync()
        {
            // Arrange
            BootstrapperTestResult xx = await Bootstrapper
                .Factory
                .CreateDocs(Array.Empty<string>())
                .SetRootPath(@"C:/docgen")
                .AddSetting("SourceFiles", "src/osisa.Project/**/*.cs")
                .RunTestAsync();

            // Act
            // Assert
        }

        [TestMethod]
        public async Task CollectAsync()
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
