using MDD4All.UI.DataModels.Tree;
using Microsoft.AspNetCore.Components;
          
namespace MDD4All.UI.BlazorComponents.Tree
{
    public partial class MvvmTree<TNode>
    {
        [Parameter]
        public IEnumerable<ITreeNode> Nodes { get; set; }

        [Parameter]
        public bool Visible { get; set; } = true;

        [Parameter]
        public RenderFragment<TNode> TitleTemplate { get; set; }

        [Parameter]
        public TreeStyle Style { get; set; } = TreeStyle.Bootstrap;


        [Parameter]
        public EventCallback<ITreeNode> SelectedNodeChanged { get; set; }


        private async Task OnToggleNode(ITreeNode node, bool expand)
        {
            var expanded = node.IsExpanded;
            // colapse
            if (expanded && !expand)
            {
                // remove from expanded list
                node.IsExpanded =  false;
                // trigger 'ExpandedNodesChanged'
                //await ExpandedNodesChanged.InvokeAsync(ExpandedNodes);
            }
            // expand
            else if (!expanded && expand)
            {
                node.IsExpanded = true;
            }

            

            StateHasChanged();
        }

        private void OnSelectNode(ITreeNode node)
        {
            if(node.SelectedNode != null)
            {
                node.SelectedNode.IsSelected = false;
            }

            node.SelectedNode = node;
            node.SelectedNode.IsSelected = true;

            //if (node.IsDisabled)
            //{
            //    return;
            //}

            
            SelectedNodeChanged.InvokeAsync(node);

            
        }

        private ITreeNode FindRootNode(ITreeNode currentNode)
        {
            ITreeNode node = currentNode;
            while(node.Parent != null)
            {
                node = node.Parent;
            }

            return node;
        }

        private void DeselectAllNodes(ITreeNode contextNode)
        {
            ITreeNode rootNode = FindRootNode(contextNode);

            DeselectAllNodesRecusrsively(rootNode);
        }

        private void DeselectAllNodesRecusrsively(ITreeNode node)
        {
            node.IsSelected = false;

            foreach(ITreeNode child in node.Children)
            {
                DeselectAllNodesRecusrsively(child);
            }
        }

    }
}