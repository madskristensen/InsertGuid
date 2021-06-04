using System;
using Community.VisualStudio.Toolkit;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace InsertGuid
{
    [Command(PackageGuids.guidInsertGuidCmdSetString, PackageIds.cmdInsertGuid)]
    public class InsertGuidCommand : BaseCommand<InsertGuidCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            TextDocument doc = await VS.Editor.GetActiveTextDocumentAsync();
            doc?.Selection.Insert(Guid.NewGuid().ToString());
        }
    }
}
