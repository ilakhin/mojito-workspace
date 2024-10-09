namespace IL.Mojito
{
    public sealed class Widget
    {
        public readonly WidgetModel Model;
        public readonly string ViewKey;
        public readonly int Priority;

        public Widget(WidgetModel model, string viewKey, int priority)
        {
            Model = model;
            ViewKey = viewKey;
            Priority = priority;
        }
    }
}
