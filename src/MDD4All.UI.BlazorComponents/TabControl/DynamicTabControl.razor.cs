using MDD4All.UI.DataModels.TabControl;
using Microsoft.AspNetCore.Components;
using System.Collections.Specialized;

namespace MDD4All.UI.BlazorComponents.TabControl
{
    public partial class DynamicTabControl
    {
        [Parameter]
        public ITabControl DataContext { get; set; }

        private string GetButtonClass(ITabPage page)
        {
            string result = "input-group-text ";

            if (DataContext.ActivePage == page)
            {
                result += "";
            }
            
            return result;
        }

        void ActivatePage(ITabPage page)
        {
            DataContext.ActivePage = page;

            StateHasChanged();
        }

        internal void AddPage(DynamicTabPage tabPage)
        {
            _tabPages.Add(tabPage);

            StateHasChanged();
        }

        internal int GetIndexOfPage(ITabPage page)
        {
            int result = -1;

            for (int index = 0; index < DataContext.Pages.Count; index++)
            {
                ITabPage currentPage = DataContext.Pages[index];
                if (page == currentPage)
                {
                    result = index; 
                    break;
                }
            }

            return result;
        }

        protected override void OnInitialized()
        {
            DataContext.Pages.CollectionChanged += PagesCollectionChanged;
        }

        private List<DynamicTabPage> _tabPages = new List<DynamicTabPage>();

        private void PagesCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {


            //StateHasChanged();
        }

        private void OnRemoveButtonPressed(ITabPage tabPage)
        {

            int index = GetIndexOfPage(tabPage);

            // remove also in view model
            DataContext.Pages.RemoveAt(index);

            if (DataContext.Pages.Count > 0)
            {
                if (index > 0)
                {
                    if (DataContext.Pages.Count >= index)
                    {
                        ActivatePage(DataContext.Pages[index - 1]);
                    }
                }
                else
                {

                    ActivatePage(DataContext.Pages[0]);

                }
            }

        }
    }
}