using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Commanding;
using Microsoft.VisualStudio.Editor.Commanding;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Utilities;

namespace InsertGuid.Commands
{
    [Export(typeof(CommandBindingDefinition))]
    [CommandBinding(PackageGuids.guidInsertGuidCmdSetString, PackageIds.cmdInsertGuid, typeof(InsertGuidCommandArgs))]

    [Export(typeof(ICommandHandler))]
    [Name(nameof(InsertGuidCommand))]
    [ContentType("any")]
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    public class InsertGuidCommand : ICommandHandler<InsertGuidCommandArgs>
    {
        [Import]
        private IEditorOperationsFactoryService _editorOperations = null;

        public string DisplayName => Vsix.Name;

        public bool ExecuteCommand(InsertGuidCommandArgs args, CommandExecutionContext executionContext)
        {
            IEditorOperations operations = _editorOperations.GetEditorOperations(args.TextView);
            operations.ReplaceSelection(Guid.NewGuid().ToString());

            return true;
        }

        public CommandState GetCommandState(InsertGuidCommandArgs args)
        {
            return CommandState.Available;
        }
    }
}
