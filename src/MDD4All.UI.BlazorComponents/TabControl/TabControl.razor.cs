using Microsoft.AspNetCore.Components;

namespace MDD4All.UI.BlazorComponents.TabControl
{
    public partial class TabControl
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public TabPage ActivePage { get; set; }

        List<TabPage> TabPages = new List<TabPage>();

        protected override void OnInitialized()
        {
            TabPages = new List<TabPage>();
        }

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
            TabPages.Add(tabPage);
            if (TabPages.Count == 1)
            {
                ActivePage = tabPage;
            }

            StateHasChanged();
        }

        
    }

}