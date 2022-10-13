using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MDD4All.UI.BlazorComponents.TabControl
{
    public partial class TabPage
    {
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