// --------------------------------------------------------------------------------------------------------------------
// <copyright company="o.s.i.s.a. GmbH" file="SolutionAssemblyInfo.cs">
//    (c) 2014. See licence text in binary folder.
// </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Security;

// System.Security
// [assembly: AllowPartiallyTrustedCallers]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: CLSCompliant(true)]
[assembly: SecurityRules(SecurityRuleSet.Level1)]

/// <summary>
///     General SolutionDescription used by all projects.
/// </summary>
/// <remarks>
///     Used as a linked file.
///     This file will be adapted within the UpdateAssemblyInfoFiles task in the solution item
///     osisa.NETBase.Smart.VersionNumber.targets.
///     this only happens if the $(BuildEnvironment is set to 'DEV'.)
/// </remarks>
internal static class SolutionInfo
{
    #region Constants

    /// <summary>
    ///     Solution wide company name for the assemblyInfo files.
    /// </summary>
    public const string Company = "o.s.i.s.a. GmbH";

    /// <summary>
    ///     Solution wide copyright description for the assemblyInfo files.
    /// </summary>
    public const string Copyright = "o.s.i.s.a. GmbH 2012";

    /// <summary>
    ///     Solution wide product description for the assemblyInfo files.
    /// </summary>
    public const string Product = "NETBase Framework";

    /// <summary>
    ///     Solution wide trademark description for the assemblyInfo files.
    /// </summary>
    public const string Trademark = "NETBase";

    #endregion
}