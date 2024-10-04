using TMPro;
using UnityEngine.UI;

namespace IL.Mojito
{
    public static class WidgetExtensions
    {
        public static Button GetButton(this IWidget widget, string key)
        {
            return widget.GetComponent<Button>(key);
        }

        public static TMP_Dropdown GetDropdown(this IWidget widget, string key)
        {
            return widget.GetComponent<TMP_Dropdown>(key);
        }

        public static Slider GetSlider(this IWidget widget, string key)
        {
            return widget.GetComponent<Slider>(key);
        }

        public static TMP_Text GetText(this IWidget widget, string key)
        {
            return widget.GetComponent<TMP_Text>(key);
        }

        public static Toggle GetToggle(this IWidget widget, string key)
        {
            return widget.GetComponent<Toggle>(key);
        }
    }
}
