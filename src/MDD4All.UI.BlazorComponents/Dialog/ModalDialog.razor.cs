using Microsoft.AspNetCore.Components;

namespace MDD4All.UI.BlazorComponents.Dialog
{
    public partial class ModalDialog
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<bool> OnClose { get; set; }

        [Parameter]
        public ModalDialogType DialogType { get; set; } = ModalDialogType.Ok;

        private Task ModalCancel()
        {
            return OnClose.InvokeAsync(false);
        }

        private Task ModalOk()
        {
            return OnClose.InvokeAsync(true);
        }

        public enum ModalDialogType
        {
            Ok,
            OkCancel,
            DeleteCancel
        }
    }
}