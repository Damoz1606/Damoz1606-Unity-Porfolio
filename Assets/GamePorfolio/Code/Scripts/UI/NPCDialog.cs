using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    private TMPro.TextMeshPro _dialogBox;
    private UnityEngine.UI.Image _moreImage;

    private void Awake()
    {
        // textGenerator = new TextGenerator();
        // textGenerationSettings = _dialogBox.GetGenerationSettings(_dialogBox.rectTransform.rect.size);
    }


    private List<string> _lines = new List<string>();
    private int _currentLine = 0;

    // public string Text {
    //     set {
    //         _lines = value;
    //     }
    // }

    void Start()
    {
        this._dialogBox = this.GetComponentInChildren<TMPro.TextMeshPro>();
        this._moreImage = this.GetComponentInChildren<UnityEngine.UI.Image>();
    }

    public bool NextLine()
    {
        if (this._lines.Count == 0) return false;
        this._dialogBox.text = this._lines[_currentLine];
        this._currentLine++;
        if (this._currentLine >= this._lines.Count) return false;
        return true;
    }

    private bool TextToLine() {
        return false;
    }


}
