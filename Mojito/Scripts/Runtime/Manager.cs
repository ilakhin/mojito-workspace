using ObservableCollections;

namespace IL.Mojito
{
    public sealed class Manager
    {
        public readonly ObservableHashSet<Widget> _widgets = new();

        public void AddWidget(Widget widget)
        {
            _widgets.Add(widget);
        }
        
        public void RemoveWidget(Widget widget)
        {
            _widgets.Add(widget);
        }
    }
}
