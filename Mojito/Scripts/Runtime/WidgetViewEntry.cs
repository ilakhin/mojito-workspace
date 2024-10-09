using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace IL.Mojito
{
    [Serializable]
    public sealed class WidgetViewEntry
    {
        [Required]
        [SerializeField]
        private string _key;

        [Required]
        [SerializeField]
        private WidgetView _widgetView;

        public string Key => _key;

        public WidgetView WidgetView => _widgetView;
    }
}
