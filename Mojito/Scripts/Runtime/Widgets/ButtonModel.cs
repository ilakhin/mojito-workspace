using R3;

namespace IL.Mojito
{
    public sealed class ButtonModel : WidgetModel
    {
        public readonly Subject<Unit> Click = new();
    }
}
