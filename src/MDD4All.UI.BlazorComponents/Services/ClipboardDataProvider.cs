using Microsoft.JSInterop;

namespace MDD4All.UI.BlazorComponents.Services
{
    public sealed class ClipboardDataProvider
    {
        private readonly IJSRuntime _jsRuntime;

        public ClipboardDataProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask<string> ReadTextAsync()
        {
            return _jsRuntime.InvokeAsync<string>("navigator.clipboard.readText");
        }

        public ValueTask WriteTextAsync(string text)
        {
            return _jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
        }
    }
}
