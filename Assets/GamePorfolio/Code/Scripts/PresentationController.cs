using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class PresentationController : DialogueController
{
    [Space(10)]
    [Header("Presentation values")]
    [TextArea(5, 10)]
    public string Text;

    private string _text;

    public string TextMessage { get => _text; set => _text = value; }

    protected override void Start()
    {
        base.Start();
        this.TextMessage = Text;
    }

    private void OnEnable()
    {
        this.TextMessage = Text;
    }

    public void InitMessage()
    {
        this.StartDialogue(this.TextMessage);
        this.NextSentence();
    }
}
