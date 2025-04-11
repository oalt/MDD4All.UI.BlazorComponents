namespace MDD4All.UI.BlazorComponents.Services
{
    public class DragDropDataProvider
    {
        private object _data;

        public void SetData(object data)
        {
            _data = data;
        }
        
        public object GetData()
        {
            return _data;   
        }
    }

}
