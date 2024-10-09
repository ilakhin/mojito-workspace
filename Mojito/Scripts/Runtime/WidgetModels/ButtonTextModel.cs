namespace IL.Mojito
{
    public abstract class ButtonTextModel : WidgetModel
    {
        public readonly ButtonModel ButtonModel;
        public readonly TextModel TextModel;

        public ButtonTextModel(ButtonModel buttonModel, TextModel textModel)
        {
            ButtonModel = buttonModel;
            TextModel = textModel;
        }
    }
}
