using System.Threading;
using Sirenix.OdinInspector;
using UnityEngine;

namespace IL.Mojito
{
    public sealed class DropdownButtonView : WidgetView<DropdownButtonModel>
    {
        [ChildGameObjectsOnly]
        [Required]
        [SerializeField]
        private DropdownView _dropdownView;

        [ChildGameObjectsOnly]
        [Required]
        [SerializeField]
        private ButtonView _buttonView;

        protected override void OnInitialize(DropdownButtonModel model, CancellationToken cancellationToken)
        {
            base.OnInitialize(model, cancellationToken);

            _dropdownView.Initialize(model.DropdownModel, cancellationToken);
            _buttonView.Initialize(model.ButtonModel, cancellationToken);
        }
    }
}
