using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextUtils : MonoBehaviour
{
    [Header("Values")]
    public string Text;

    private string _text;
    private bool _allowAction = false;

    private void Start()
    {
        if (this.Text == string.Empty || this.Text == null)
            throw new System.Exception("Please assign a text");
        this._text = this.Text;
    }

    public void EnableAction()
    {
        this._allowAction = true;
    }
    public void DisableAction()
    {
        this._allowAction = false;
    }

    public void Copy()
    {
        if (!this._allowAction) return;
        this.DisableAction();
#if UNITY_WEBGL
        TextEditor textEditor = new TextEditor();
        textEditor.text = this._text;
        textEditor.SelectAll();
        textEditor.Copy();
#else
        TextEditor textEditor = new TextEditor();
        textEditor.text = this._text;
        textEditor.SelectAll();
        textEditor.Copy();
#endif
    }

    public void OpenLink()
    {
        if (!this._allowAction) return;
        this.DisableAction();
        Application.OpenURL(this._text);
    }
}
