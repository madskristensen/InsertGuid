using System;
using System.Linq;
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
            var docView = await VS.Documents.GetActiveDocumentViewAsync();
            var selection = docView.TextView?.Selection.SelectedSpans.FirstOrDefault();

            docView?.TextBuffer.Replace(selection.Value, Guid.NewGuid().ToString());
        }
    }
}
