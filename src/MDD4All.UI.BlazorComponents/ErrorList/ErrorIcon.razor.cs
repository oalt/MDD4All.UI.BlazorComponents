using MDD4All.UI.DataModels.ErrorList;
using Microsoft.AspNetCore.Components;

namespace MDD4All.UI.BlazorComponents.ErrorList
{
    public partial class ErrorIcon
    {
        [Parameter]
        public IErrorListElement DataContext { get; set; } = null!;
    }
}