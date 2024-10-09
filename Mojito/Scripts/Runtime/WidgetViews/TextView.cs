using System.Threading;
using JetBrains.Annotations;
using R3;
using TMPro;
using UnityEngine;

namespace IL.Mojito
{
    [RequireComponent(typeof(TMP_Text))]
    public sealed class TextView : WidgetView<TextModel>
    {
        private TMP_Text _text;

        protected override void OnInitialize(TextModel model, CancellationToken cancellationToken)
        {
            base.OnInitialize(model, cancellationToken);

            model.Value
                .Subscribe(_text, static (value, text) => text.text = value)
                .RegisterTo(cancellationToken);
        }

        [UsedImplicitly]
        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        [UsedImplicitly]
        private void OnDestroy()
        {
            _text = default;
        }
    }
}
