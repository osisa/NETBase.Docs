using Statiq.Docs;
using Statiq.Testing;

await Bootstrapper
    .Factory
    .CreateDocs(args)
    .SetRootPath(@"C:/TestBin")
    ////.AddAssemblyFiles("src/**/*.dll")
    .AddSolutionFiles(@"**/*.sln")
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
