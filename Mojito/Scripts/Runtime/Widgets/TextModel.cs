using R3;

namespace IL.Mojito
{
    public sealed class TextModel : WidgetModel
    {
        public readonly ReactiveProperty<string> Value = new(string.Empty);
    }
}
