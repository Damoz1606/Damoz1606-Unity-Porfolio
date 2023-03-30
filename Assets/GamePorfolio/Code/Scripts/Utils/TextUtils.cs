using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUtils : MonoBehaviour
{
    [Header("Values")]
    public string Text;

    private string _text;

    private void Start()
    {
        if (this.Text == string.Empty || this.Text == null)
            throw new System.Exception("Please assign a text");
        this._text = this.Text;
    }

    public void Copy()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.text = this._text;
        textEditor.SelectAll();
        textEditor.Copy();
    }

    public void OpenLink()
    {
        Application.OpenURL(this._text);
    }
}
