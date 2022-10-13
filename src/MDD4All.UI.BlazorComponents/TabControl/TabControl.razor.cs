using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MDD4All.UI.BlazorComponents.TabControl
{
    public partial class TabControl
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public TabPage ActivePage { get; set; }

        List<TabPage> Pages = new List<TabPage>();
        string GetButtonClass(TabPage page)
        {
            return page == ActivePage ? "nav-link active" : "nav-link";
        }

        void ActivatePage(TabPage page)
        {
            ActivePage = page;
        }

        internal void AddPage(TabPage tabPage)
        {
            Pages.Add(tabPage);
            if (Pages.Count == 1)
            {
                ActivePage = tabPage;
            }

            StateHasChanged();
        }
    }
}