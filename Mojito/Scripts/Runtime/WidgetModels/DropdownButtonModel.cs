namespace IL.Mojito
{
    public abstract class DropdownButtonModel : WidgetModel
    {
        public readonly DropdownModel DropdownModel;
        public readonly ButtonModel ButtonModel;

        public DropdownButtonModel(DropdownModel dropdownModel, ButtonModel buttonModel)
        {
            DropdownModel = dropdownModel;
            ButtonModel = buttonModel;
        }
    }
}
