using MDD4All.Localization.Contracts;
using Microsoft.AspNetCore.Components;

namespace MDD4All.UI.BlazorComponents.Localization
{
    public partial class LanguageSelection
    {
        [Inject]
        ILanguageSetter LanguageSetter { get; set; } = null!;


        private async void OnChangeLanguage(string languageCode)
        {
            LanguageSetter.SetCulture(languageCode);
        }

    }
}