using System.Threading;
using JetBrains.Annotations;
using R3;
using TMPro;
using UnityEngine;

namespace IL.Mojito
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public sealed class DropdownView : WidgetView<DropdownModel>
    {
        private TMP_Dropdown _dropdown;

        protected override void OnInitialize(DropdownModel model, CancellationToken cancellationToken)
        {
            base.OnInitialize(model, cancellationToken);

            model.Value
                .Subscribe(_dropdown, static (value, dropdown) => dropdown.value = value)
                .RegisterTo(cancellationToken);

            OnValueChangedAsObservable(_dropdown)
                .Subscribe(model, static (value, model) => model.OnValueChanged(value))
                .RegisterTo(cancellationToken);
        }

        private static Observable<int> OnValueChangedAsObservable(TMP_Dropdown dropdown)
        {
            return Observable.Create<int, TMP_Dropdown>(dropdown, static (observer, dropdown) =>
            {
                observer.OnNext(dropdown.value);

                return dropdown.onValueChanged
                    .AsObservable(dropdown.destroyCancellationToken)
                    .Subscribe(observer);
            });
        }

        [UsedImplicitly]
        private void Awake()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
        }

        [UsedImplicitly]
        private void OnDestroy()
        {
            _dropdown = default;
        }
    }
}
