using MDD4All.UI.DataModels.ErrorList;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MDD4All.UI.BlazorComponents.ErrorList
{
    public partial class ErrorListPanel
    {
        [Inject]
        public IStringLocalizer<ErrorListPanel> L { get; set; } = null!;

        [Parameter]
        public IStringLocalizer? EL { get; set; }

        [Parameter]
        public IErrorList DataContext { get; set; } = null!;

        [Parameter]
        public bool ShowTitle { get; set; } = false;
    }
}