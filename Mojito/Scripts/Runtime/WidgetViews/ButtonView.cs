using System.Threading;
using JetBrains.Annotations;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace IL.Mojito
{
    [RequireComponent(typeof(Button))]
    public sealed class ButtonView : WidgetView<ButtonModel>
    {
        private Button _button;

        protected override void OnInitialize(ButtonModel model, CancellationToken cancellationToken)
        {
            base.OnInitialize(model, cancellationToken);

            OnClickAsObservable(_button)
                .Subscribe(model, static (_, model) => model.OnClick())
                .RegisterTo(cancellationToken);
        }

        private static Observable<Unit> OnClickAsObservable(Button button)
        {
            return button.onClick.AsObservable(button.destroyCancellationToken);
        }

        [UsedImplicitly]
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        [UsedImplicitly]
        private void OnDestroy()
        {
            _button = default;
        }
    }
}
