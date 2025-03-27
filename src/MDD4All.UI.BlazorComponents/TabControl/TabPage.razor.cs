using Microsoft.AspNetCore.Components;

namespace MDD4All.UI.BlazorComponents.TabControl
{
    public partial class TabPage
    {
        //[Parameter]
        //public ViewModelBase

        [CascadingParameter]
        private TabControl Parent { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; }

        //[Parameter]
        //public string Text { get; set; }
        protected override void OnInitialized()
        {
            if (Parent == null)
            {
                throw new ArgumentNullException(nameof(Parent), "TabPage must exist within a TabControl");
            }

            base.OnInitialized();
            Parent.AddPage(this);
        }
    }
}