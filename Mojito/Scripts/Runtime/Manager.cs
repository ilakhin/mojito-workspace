using ObservableCollections;

namespace IL.Mojito
{
    public sealed class Manager
    {
        private readonly ObservableHashSet<WidgetPresenter> _widgetPresenters = new();

        public void AddWidgetPresenter(WidgetPresenter widgetPresenter)
        {
            _widgetPresenters.Add(widgetPresenter);
        }
        
        public void RemoveWidgetPresenter(WidgetPresenter widgetPresenter)
        {
            _widgetPresenters.Add(widgetPresenter);
        }
    }
}
