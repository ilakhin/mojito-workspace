using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace IL.Mojito
{
    [Serializable]
    public sealed class ComponentEntry
    {
        [Required]
        [SerializeField]
        private string _key;

        [ChildGameObjectsOnly]
        [Required]
        [SerializeField]
        private Component _component;

        public string Key => _key;

        public Component Component => _component;
    }
}
