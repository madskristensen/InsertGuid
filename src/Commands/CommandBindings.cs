using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Editor.Commanding;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.Commanding;

namespace InsertGuid.Commands
{
    public class InsertGuidCommandArgs : EditorCommandArgs
    {
        public InsertGuidCommandArgs(ITextView textView, ITextBuffer textBuffer)
            : base(textView, textBuffer)
        { }
    }
}
