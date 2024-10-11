using R3;

namespace IL.Mojito
{
    public abstract class DropdownModel : WidgetModel
    {
        private readonly ReactiveProperty<int> _value = new(0);

        public ReadOnlyReactiveProperty<int> Value => _value;

        public virtual void OnValueChanged(int value)
        {
            SetValue(value);
        }

        protected void SetValue(int value)
        {
            _value.Value = value;
        }
    }
}
