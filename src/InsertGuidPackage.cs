using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace InsertGuid
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.guidInsertGuidPackageString)]
    [ProvideBindingPath]
    public sealed class InsertGuidPackage : AsyncPackage
    { }
}
