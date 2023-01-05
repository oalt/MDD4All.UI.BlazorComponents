using MDD4All.UI.DataModels.Tree;
using Microsoft.AspNetCore.Components;

namespace MDD4All.UI.BlazorComponents.Tree
{
    public partial class MvvmTree<TNode>
    {
        [Parameter]
        public ITree DataContext { get; set; }

        [Parameter]
        public RenderFragment<TNode> TitleTemplate { get; set; }

        [Parameter]
        public RenderFragment<TNode> LoadingTemplate { get; set; }

        [Parameter]
        public EventCallback<ITreeNode> SelectedNodeChanged { get; set; }

        private void OnTreeNodeStateChanged()
        {
            InvokeAsync(() => StateHasChanged());
        }
    }
}