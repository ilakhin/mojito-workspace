using R3;

namespace IL.Mojito
{
    public abstract class InputFieldModel : WidgetModel
    {
        private readonly ReactiveProperty<string> _value = new(string.Empty);

        public ReadOnlyReactiveProperty<string> Value => _value;

        public virtual void OnValueChanged(string value)
        {
            SetValue(value);
        }

        protected void SetValue(string value)
        {
            _value.Value = value;
        }
    }
}
