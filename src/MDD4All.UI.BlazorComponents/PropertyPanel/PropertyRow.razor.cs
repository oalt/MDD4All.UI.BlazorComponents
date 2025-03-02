using Microsoft.AspNetCore.Components;

namespace MDD4All.UI.BlazorComponents.PropertyPanel
{
    public partial class PropertyRow<TProperty>
    {
        [Parameter]
        public string Name { get; set; } = string.Empty;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private TProperty _value = default;

        [Parameter]
        public TProperty Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (_value == null)
                {
                    if(value != null)
                    {
                        _value = value;
                        ValueChanged.InvokeAsync(value);
                    }
                }
                else
                {
                    if (!_value.Equals(value))
                    {
                        _value = value;

                        ValueChanged.InvokeAsync(value);
                    }
                }
            }

        }

        [Parameter]
        public EventCallback<TProperty> ValueChanged { get; set; }
    }
}