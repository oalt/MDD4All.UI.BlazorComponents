using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MDD4All.UI.BlazorComponents.Tree
{
    public partial class Tree<TNode>
    {
        [Parameter]
        public IEnumerable<TNode> Nodes { get; set; }

        [Parameter]
        public RenderFragment<TNode> TitleTemplate { get; set; }

        [Parameter]
        public TNode SelectedNode { get; set; }

        [Parameter]
        public EventCallback<TNode> SelectedNodeChanged { get; set; }

        [Parameter]
        public Func<TNode, IEnumerable<TNode>> ChildSelector { get; set; } = node => null;
        [Parameter]
        public IList<TNode> ExpandedNodes { get; set; } = new List<TNode>();
        [Parameter]
        public EventCallback<IList<TNode>> ExpandedNodesChanged { get; set; }

        [Parameter]
        public TreeStyle Style { get; set; } = TreeStyle.Bootstrap;
        [Parameter]
        public bool Visible { get; set; } = true;
        [Parameter]
        public Func<TNode, bool> HasChildNodes { get; set; } = node => true;
        [Parameter]
        public Func<TNode, bool> NodeDisabled { get; set; } = node => false;
        [Parameter]
        public Func<TNode, Task> OnNodeExpand { get; set; }

        List<TNode> loadingNodes = new List<TNode>();
        private async Task OnToggleNode(TNode node, bool expand)
        {
            var expanded = ExpandedNodes.Contains(node);
            // colapse
            if (expanded && !expand)
            {
                // remove from expanded list
                ExpandedNodes.Remove(node);
                // trigger 'ExpandedNodesChanged'
                await ExpandedNodesChanged.InvokeAsync(ExpandedNodes);
            }
            // expand
            else if (!expanded && expand)
            {
                // trigger 'OnNodeExpand'
                if (OnNodeExpand != null)
                {
                    loadingNodes.Add(node);
                    await OnNodeExpand.Invoke(node);
                    loadingNodes.Remove(node);
                }

                // add to expanded list
                ExpandedNodes.Add(node);
                // trigger 'ExpandedNodesChanged'
                await ExpandedNodesChanged.InvokeAsync(ExpandedNodes);
            }

            StateHasChanged();
        }

        private void OnSelectNode(TNode node)
        {
            if (NodeDisabled(node))
            {
                return;
            }

            SelectedNode = node;
            SelectedNodeChanged.InvokeAsync(node);
        }
    }
}