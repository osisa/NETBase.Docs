// --------------------------------------------------------------------------------------------------------------------
// <copyright company="o.s.i.s.a. GmbH" file="SolutionInfo.cs">
//    (c) 2014. See licence text in binary folder.
// </copyright>
//  --------------------------------------------------------------------------------------------------------------------

#if TEST
//// SolutionInfo is omitted in case of a test project.
//// because sometimes the projects makes the internal classes visible to the test project and this would cause name conflicts.
#else

using System.Reflection;

[assembly: AssemblyTrademark(Info.SolutionInfo.Trademark)]
[assembly: AssemblyProduct(Info.SolutionInfo.Product)]
[assembly: AssemblyCompany(Info.SolutionInfo.Company)]
[assembly: AssemblyCopyright(Info.SolutionInfo.Copyright)]

namespace Info
{
    /// <summary>   Information about the solution. </summary>
    internal static class SolutionInfo
    {
        #region Constants

        /// <summary>
        ///     (Immutable)
        ///     Solution wide company name for the assemblyInfo files.
        /// </summary>
        public const string Company = "o.s.i.s.a. GmbH";

        /// <summary>
        ///     (Immutable)
        ///     Solution wide copyright description for the assemblyInfo files.
        /// </summary>
        public const string Copyright = "o.s.i.s.a. GmbH 2023";

        /// <summary>
        ///     (Immutable)
        ///     Solution wide product description for the assemblyInfo files.
        /// </summary>
        public const string Product = "NETBase Framework";

        /// <summary>(Immutable) the public key. </summary>
        public const string PublicKey = "00240000048000009400000006020000002400005253413100040000010001005b0d1b000d968fe9b0a23ddc59c685356c257f45a6f098f4ba9dcee963cb83401aa69dfd8496ecbdc02771cc5e6690ea6605a60452f8af0bcd3931df53ab0e8ecdd38953e29361c6c8e545d255efacf7bd40afbb0b371cdb86819c6bed2febe2abc41d8647dc36102f40a64c83ea0209e899c97748ab979eb148c5edcbed9e87";

        /// <summary>
        ///     (Immutable)
        ///     Solution wide trademark description for the assemblyInfo files.
        /// </summary>
        public const string Trademark = "NETBase";

        #endregion
    }
}
#endif