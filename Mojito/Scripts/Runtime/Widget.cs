using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace IL.Mojito
{
    [DisallowMultipleComponent]
    public sealed class Widget : MonoBehaviour, IWidget
    {
        [SerializeField]
        [TableList]
        private ComponentEntry[] _componentEntries;

        private Dictionary<string, Component> _components = new(StringComparer.Ordinal);
        
        private Dictionary<string, Component> Components => _components ??= _componentEntries
            .ToDictionary(static entry => entry.Key, static entry => entry.Component, StringComparer.Ordinal);

        TComponent IWidget.GetComponent<TComponent>(string key)
        {
            return (TComponent) Components[key];
        }
    }
}
