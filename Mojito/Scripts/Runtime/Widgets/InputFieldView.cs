using System.Threading;
using JetBrains.Annotations;
using R3;
using TMPro;
using UnityEngine;

namespace IL.Mojito
{
    [RequireComponent(typeof(TMP_InputField))]
    public sealed class InputFieldView : WidgetView<InputFieldModel>
    {
        private TMP_InputField _inputField;

        protected override void OnInitialize(InputFieldModel model, CancellationToken cancellationToken)
        {
            base.OnInitialize(model, cancellationToken);

            model.Value
                .Subscribe(_inputField, static (value, inputField) => inputField.text = value)
                .RegisterTo(cancellationToken);

            OnValueChangedAsObservable(_inputField)
                .Subscribe(model, static (value, model) => model.OnValueChanged(value))
                .RegisterTo(cancellationToken);
        }

        private static Observable<string> OnValueChangedAsObservable(TMP_InputField inputField)
        {
            return Observable.Create<string, TMP_InputField>(inputField, static (observer, inputField) =>
            {
                observer.OnNext(inputField.text);

                return inputField.onValueChanged.AsObservable(inputField.destroyCancellationToken).Subscribe(observer);
            });
        }

        [UsedImplicitly]
        private void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
        }

        [UsedImplicitly]
        private void OnDestroy()
        {
            _inputField = default;
        }
    }
}
