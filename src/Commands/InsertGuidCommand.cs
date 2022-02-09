using System;
using System.Linq;
using Community.VisualStudio.Toolkit;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text;
using Task = System.Threading.Tasks.Task;

namespace InsertGuid
{
    [Command(PackageGuids.guidInsertGuidCmdSetString, PackageIds.cmdInsertGuid)]
    public class InsertGuidCommand : BaseCommand<InsertGuidCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            DocumentView docView = await VS.Documents.GetActiveDocumentViewAsync();
            NormalizedSnapshotSpanCollection selections = docView.TextView?.Selection.SelectedSpans;

            if (selections == null)
                return;

            using (ITextEdit edit = docView.TextBuffer.CreateEdit())
            {
                var guid = Guid.NewGuid().ToString();

                foreach (SnapshotSpan selection in selections.Reverse())
                {
                    edit.Replace(selection, guid);
                }

                edit.Apply();
            }
        }
    }
}
