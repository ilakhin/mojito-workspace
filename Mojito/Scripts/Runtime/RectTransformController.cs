using JetBrains.Annotations;
using UnityEngine;

namespace IL.Mojito
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    public sealed class RectTransformController : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private void UpdateRectTransform()
        {
            var safeArea = Screen.safeArea;
            var currentResolution = Screen.currentResolution;

            var xMin = safeArea.xMin / currentResolution.width;
            var xMax = safeArea.xMax / currentResolution.width;

            var yMin = safeArea.yMin / currentResolution.height;
            var yMax = safeArea.yMax / currentResolution.height;

            _rectTransform.anchorMin = new Vector2(xMin, yMin);
            _rectTransform.anchorMax = new Vector2(xMax, yMax);
        }

        [UsedImplicitly]
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        [UsedImplicitly]
        private void OnDestroy()
        {
            _rectTransform = default;
        }

        [UsedImplicitly]
        private void Start()
        {
            UpdateRectTransform();
        }

        [UsedImplicitly]
        private void Update()
        {
            UpdateRectTransform();
        }
    }
}
