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

    protected override void Start()
    {
        base.Start();
        this.StartDialogue(this.Text);
        this.NextSentence();
    }
}
