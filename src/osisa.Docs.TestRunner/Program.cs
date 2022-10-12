using Statiq.Docs;
using Statiq.Testing;

await Bootstrapper
    .Factory
    .CreateDocs(args)
    .SetRootPath(@"C:/TestBin")
    //.AddSetting("SourceFiles", "../src/**/TestCoreClassLibrary.csproj")
    //.AddProjectFiles("../src/**/TestCoreClassLibrary.csproj")

    .AddSetting("SourceFiles", "../src/TestSolution.sln")
    .AddProjectFiles("../src/TestSolution.sln")

    ////.AddAssemblyFiles("src/**/*.dll")
    ////.AddSolutionFiles(@"**/*.sln")
    ////.AddSetting("SourceFiles", string.Empty)
    .RunAsync();

    ////.BuildPipeline("collect", builder => builder
    ////    .WithInputModules(new ReadFiles("*.*"))
    ////    ////.WithProcessModules(new )
    ////    .WithOutputModules(new WriteFiles()))
    ////.RunAsync();

////await Bootstrapper
////                .Factory
////                .CreateDefault(Array.Empty<string>())
////                .BuildPipeline("collect", builder => builder
////                    .WithInputModules(new ReadFiles("*.*"))
////                    ////.WithProcessModules(new )
////                    .WithOutputModules(new WriteFiles()))
////                .RunAsync();
