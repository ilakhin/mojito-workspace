using System.Threading;
using UnityEngine;
using UnityEngine.Assertions;

namespace IL.Mojito
{
    [DisallowMultipleComponent]
    public abstract class WidgetView : MonoBehaviour
    {
        private CancellationTokenSource _cancellationTokenSource;

        public void Initialize(WidgetModel model, CancellationToken cancellationToken)
        {
            Assert.IsNull(_cancellationTokenSource);

            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(destroyCancellationToken, cancellationToken);

            OnInitialize(model, _cancellationTokenSource.Token);
        }

        protected virtual void OnInitialize(WidgetModel model, CancellationToken cancellationToken)
        {
        }

        public void Release()
        {
            Assert.IsNotNull(_cancellationTokenSource);

            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = default;

            OnRelease();
        }

        protected virtual void OnRelease()
        {
        }
    }

    public abstract class WidgetView<TWidgetModel> : WidgetView
        where TWidgetModel : WidgetModel
    {
        protected sealed override void OnInitialize(WidgetModel model, CancellationToken cancellationToken)
        {
            OnInitialize((TWidgetModel)model, cancellationToken);
        }

        protected virtual void OnInitialize(TWidgetModel model, CancellationToken cancellationToken)
        {
        }
    }
}
