using UnityEngine;

namespace IL.Mojito
{
    public interface IWidget
    {
        TComponent GetComponent<TComponent>(string key)
            where TComponent : Component;
    }
}
