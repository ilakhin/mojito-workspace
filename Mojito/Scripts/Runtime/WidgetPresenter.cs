namespace IL.Mojito
{
    public abstract class WidgetPresenter
    {
        public readonly string WidgetKey;
        public readonly int Priority;

        protected WidgetPresenter(string widgetKey, int priority)
        {
            WidgetKey = widgetKey;
            Priority = priority;
        }

        public void Initialize(IWidget widget)
        {
            OnInitialize(widget);
        }

        public void Release()
        {
            OnRelease();
        }
        
        protected abstract void OnInitialize(IWidget widget);
        
        protected abstract void OnRelease();
    }

    public sealed class ButtonWidgetPresenter : WidgetPresenter
    {
        public ButtonWidgetPresenter(string widgetKey, int priority) : base(widgetKey, priority)
        {
        }

        protected override void OnInitialize(IWidget widget)
        {
            var button = widget.GetButton("Button");
            var text = widget.GetText("Text");
        }

        protected override void OnRelease()
        {
            
        }
    }
}
