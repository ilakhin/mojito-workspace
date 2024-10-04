using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace IL.Mojito
{
    [Serializable]
    public sealed class WidgetEntry
    {
        [Required]
        [SerializeField]
        private string _key;

        [Required]
        [SerializeField]
        private Widget _widget;

        public string Key => _key;

        public Widget Widget => _widget;
    }
}
