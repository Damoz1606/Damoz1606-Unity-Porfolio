using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontManager : MonoBehaviour
{
    [SerializeField] public TMPro.TMP_FontAsset Font;

    private void Start()
    {
        this.UpdateTextMeshProFonts();
        this.UpdateTextMeshProUGUIFonts();
    }

    private void UpdateTextMeshProFonts()
    {
        var textComponents = Component.FindObjectsOfType<TMPro.TextMeshPro>();
        foreach (var component in textComponents)
            component.font = Font;
    }

    private void UpdateTextMeshProUGUIFonts()
    {
        var textComponents = Component.FindObjectsOfType<TMPro.TextMeshProUGUI>();
        foreach (var component in textComponents)
            component.font = Font;
    }
}
