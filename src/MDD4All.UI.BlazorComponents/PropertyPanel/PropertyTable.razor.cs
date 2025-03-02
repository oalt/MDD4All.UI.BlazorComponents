using Microsoft.AspNetCore.Components;

namespace MDD4All.UI.BlazorComponents.PropertyPanel
{
    public partial class PropertyTable
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; } = default!;
    }
}