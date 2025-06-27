using MDD4All.UI.DataModels.DragDrop;

namespace MDD4All.UI.BlazorComponents.Services
{
    public class DragDropDataProvider
    {
        private DragDropInformation _data;

        public void SetData(DragDropInformation data)
        {
            _data = data;
        }
        
        public DragDropInformation GetData()
        {
            return _data;   
        }
    }

}
