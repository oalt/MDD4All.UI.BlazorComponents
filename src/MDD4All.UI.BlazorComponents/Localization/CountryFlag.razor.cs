using Microsoft.AspNetCore.Components;

namespace MDD4All.UI.BlazorComponents.Localization
{
    public partial class CountryFlag
    {
        [Parameter]
        public string CountryCode { get; set; } = null!;

        public string ImagePath
        {
            get
            {
                string result = "_content/MDD4All.UI.BlazorComponents/images/";

                switch(CountryCode)
                {
                    case "de-DE":
                        result += "de.svg";
                        break;

                    case "en-US":
                        result += "us.svg";
                        break;

                    default:
                        result = "";
                        break;
                }

                return result;

            }
        }
    }
}