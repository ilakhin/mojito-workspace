using System.Threading;
using Sirenix.OdinInspector;
using UnityEngine;

namespace IL.Mojito
{
    public sealed class ButtonTextView : WidgetView<ButtonTextModel>
    {
        [Required]
        [SerializeField]
        private ButtonView _buttonView;
        
        [Required]
        [SerializeField]
        private TextView _textView;
        
        protected override void OnInitialize(ButtonTextModel model, CancellationToken cancellationToken)
        {
            base.OnInitialize(model, cancellationToken);

            _buttonView.Initialize(model.ButtonModel, cancellationToken);
            _textView.Initialize(model.TextModel, cancellationToken);
        }
    }
}
