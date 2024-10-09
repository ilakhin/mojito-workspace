using R3;

namespace IL.Mojito
{
    public abstract class TextModel : WidgetModel
    {
        private readonly ReactiveProperty<string> _value = new(string.Empty);

        public ReadOnlyReactiveProperty<string> Value => _value;

        protected void SetText(string text)
        {
            _value.Value = text;
        }
    }
}
