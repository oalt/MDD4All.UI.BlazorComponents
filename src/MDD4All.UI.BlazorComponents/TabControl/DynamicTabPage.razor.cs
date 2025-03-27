using MDD4All.UI.DataModels.TabControl;
using Microsoft.AspNetCore.Components;

namespace MDD4All.UI.BlazorComponents.TabControl
{
    public partial class DynamicTabPage
    {
        private DynamicTabControl _parent;

        [CascadingParameter]
        public DynamicTabControl Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        [Parameter]
        public ITabPage DataContext { get; set; }

        protected override void OnInitialized()
        {
            if (Parent == null)
            {
                throw new ArgumentNullException(nameof(Parent), "TabPage must exist within a TabControl");
            }

            base.OnInitialized();
            _parent.AddPage(this);
        }

        public override string ToString()
        {
            return DataContext?.Header + ", " + base.ToString();
        }
    }
}