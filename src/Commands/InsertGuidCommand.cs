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
        private static DTE2 _dte;

        public static async Task InitializeAsync(AsyncPackage package)
        {
            _dte = await package.GetServiceAsync(typeof(DTE)) as DTE2;

            if (await package.GetServiceAsync(typeof(IMenuCommandService)) is OleMenuCommandService commandService)
            {
                var cmdId = new CommandID(PackageGuids.guidInsertGuidCommandPackageCmdSet, PackageIds.InsertGuidCommandId);
                var menuItem = new MenuCommand(Execute, cmdId);
                commandService.AddCommand(menuItem);
            }
        }

        private static void Execute(object sender, EventArgs e)
        {
            IDataObject data = Clipboard.GetDataObject();
            Clipboard.SetText(Guid.NewGuid().ToString(), TextDataFormat.Text);

            try
            {
                _dte.ExecuteCommand("Edit.Paste");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }
            finally
            {
                Clipboard.SetDataObject(data);
            }
        }
    }
}
