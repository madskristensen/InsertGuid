using System;
using System.ComponentModel.Design;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace InsertGuid
{
    internal sealed class InsertGuidCommand
    {
        public static async Task InitializeAsync(AsyncPackage package)
        {
            if (await package.GetServiceAsync(typeof(IMenuCommandService)) is OleMenuCommandService commandService)
            {
                var cmdId = new CommandID(PackageGuids.guidInsertGuidCommandPackageCmdSet, PackageIds.InsertGuidCommandId);
                var menuItem = new MenuCommand(Execute, cmdId);
                commandService.AddCommand(menuItem);
            }
        }

        private static void Execute(object sender, EventArgs e)
        {
            var dte = Package.GetGlobalService(typeof(DTE)) as DTE2;
            Command cmd = dte.Commands.Item("Edit.Paste");

            if (cmd != null && cmd.IsAvailable)
            {
                IDataObject existing = Clipboard.GetDataObject();
                Clipboard.SetText(Guid.NewGuid().ToString(), TextDataFormat.Text);
                dte.Commands.Raise(cmd.Guid, cmd.ID, null, null);
                Clipboard.SetDataObject(existing);
            }
            else
            {
                Clipboard.SetText(Guid.NewGuid().ToString(), TextDataFormat.Text);
                dte.StatusBar.Text = "New GUID copied to clipboard";
            }
        }
    }
}
