using System.Collections.Generic;
using UnityEngine;

public class TextGroup : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] public Color color;
    [SerializeField] public TMPro.TMP_FontAsset font;

    protected List<TMPro.TextMeshProUGUI> _texts;

    private Color _color;

    private TMPro.TMP_FontAsset _font;

    protected virtual void Awake()
    {
        this._color = color;
        this._font = font;
        this._texts = new List<TMPro.TextMeshProUGUI>();
    }

    protected virtual void Start()
    {
        this._texts.AddRange(GetComponentsInChildren<TMPro.TextMeshProUGUI>());
        this._texts.ForEach(element =>
        {
            element.color = this._color;
            element.font = this._font;
        });
    }
}