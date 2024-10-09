using System;
using System.Collections.Generic;
using System.Linq;
using ObservableCollections;
using R3;
using Sirenix.OdinInspector;
using UnityEngine;

namespace IL.Mojito
{
    [DisallowMultipleComponent]
    public sealed class Popup : MonoBehaviour
    {
        [SerializeField]
        [TableList]
        private WidgetViewEntry[] _widgetEntries;

        private Dictionary<string, WidgetView> _widgetViewTemplates;
        private Dictionary<Widget, WidgetView> _widgetViews;

        private Dictionary<string, WidgetView> WidgetViewTemplates => _widgetViewTemplates ??= _widgetEntries
            .ToDictionary(static entry => entry.Key, static entry => entry.WidgetView, StringComparer.Ordinal);

        private Dictionary<Widget, WidgetView> WidgetViews => _widgetViews ??= new Dictionary<Widget, WidgetView>();

        public void Initialize(ObservableHashSet<Widget> widgets)
        {
            foreach (var widget in widgets)
            {
                CreateWidgetView(widget);
            }

            widgets
                .ObserveAdd(destroyCancellationToken)
                .Subscribe(this, static (addEvent, popup) => popup.CreateWidgetView(addEvent.Value))
                .AddTo(this);

            widgets
                .ObserveRemove(destroyCancellationToken)
                .Subscribe(this, static (removeEvent, popup) => popup.DestroyWidgetView(removeEvent.Value))
                .AddTo(this);
        }

        public void Release()
        {
        }

        private void CreateWidgetView(Widget widget)
        {
            var widgetViewTemplate = WidgetViewTemplates[widget.ViewKey];
            var widgetView = Instantiate(widgetViewTemplate, transform);

            widgetView.Initialize(widget.Model, destroyCancellationToken);

            WidgetViews.Add(widget, widgetView);
        }

        private void DestroyWidgetView(Widget widget)
        {
            if (!WidgetViews.Remove(widget, out var widgetView))
            {
                return;
            }

            widgetView.Release();

            Destroy(widgetView.gameObject);
        }
    }
}
