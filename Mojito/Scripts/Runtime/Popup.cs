using System;
using System.Collections.Generic;
using System.Linq;
using ObservableCollections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace IL.Mojito
{
    [DisallowMultipleComponent]
    public sealed class Popup : MonoBehaviour
    {
        [SerializeField]
        [TableList]
        private WidgetEntry[] _widgetEntries;

        private Dictionary<string, Widget> _widgetTemplates;
        private Dictionary<WidgetPresenter, Widget> _widgets;
        
        private Dictionary<string, Widget> WidgetTemplates => _widgetTemplates ??= _widgetEntries
            .ToDictionary(static entry => entry.Key, static entry => entry.Widget, StringComparer.Ordinal);

        private Dictionary<WidgetPresenter, Widget> Widgets => _widgets ??= new Dictionary<WidgetPresenter, Widget>();
        
        public void Initialize(ObservableHashSet<WidgetPresenter> widgetPresenters)
        {
            foreach (var widgetPresenter in widgetPresenters)
            {
                var widgetTemplate = WidgetTemplates[widgetPresenter.WidgetKey];
                var widget = Instantiate(widgetTemplate, transform);
                
                widgetPresenter.Initialize(widget);
                
                Widgets.Add(widgetPresenter, widget);
            }
        }
        
    }
}
