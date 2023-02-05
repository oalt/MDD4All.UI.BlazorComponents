using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MDD4All.UI.BlazorComponents.Dialog
{
    public partial class ModalDialog
    {
        [Inject]
        private IStringLocalizer<ModalDialog> L { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<bool> OnClose { get; set; }

        [Parameter]
        public ModalDialogType DialogType { get; set; } = ModalDialogType.Ok;

        [Parameter]
        public bool CanConfirm 
        { 
            get;
            
            set; 
        
        } = true;

        

        protected override void OnInitialized()
        {
            
        }

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