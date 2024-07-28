using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace IL.Mojito
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CanvasScaler))]
    public sealed class CanvasScalerController : MonoBehaviour
    {
        [SerializeField]
        private Vector2 _albumReferenceResolution;

        [SerializeField]
        private float _albumMatch;

        [SerializeField]
        private Vector2 _portraitReferenceResolution;

        [SerializeField]
        private float _portraitMatch;

        private CanvasScaler _canvasScaler;

        private void UpdateCanvasScaler()
        {
            var album = Screen.width > Screen.height;

            if (album)
            {
                _canvasScaler.referenceResolution = _albumReferenceResolution;
                _canvasScaler.matchWidthOrHeight = _albumMatch;
            }
            else
            {
                _canvasScaler.referenceResolution = _portraitReferenceResolution;
                _canvasScaler.matchWidthOrHeight = _portraitMatch;
            }
        }

        [UsedImplicitly]
        private void Awake()
        {
            _canvasScaler = GetComponent<CanvasScaler>();
        }

        [UsedImplicitly]
        private void OnDestroy()
        {
            _canvasScaler = default;
        }

        [UsedImplicitly]
        private void Start()
        {
            UpdateCanvasScaler();
        }

        [UsedImplicitly]
        private void Update()
        {
            UpdateCanvasScaler();
        }
    }
}
