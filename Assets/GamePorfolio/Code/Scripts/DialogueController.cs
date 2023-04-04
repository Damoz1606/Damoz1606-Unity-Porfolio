using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [Header("Dialogue Values")]
    [SerializeField] private float speed;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private List<string> sentences = new List<string>();

    [Space(10)]
    [Header("Sound Effects")]
    [SerializeField] public AudioClip SxEffect;

    private int _currentIndex = 0;
    private bool _dialogueFlag = false;
    private bool _dialogueIsBeenWritting = false;
    private bool _hasSoundEffect = false;

    private CanvasGroup canvas;

    private AudioClip _sxEffect;

    public bool HasDialogueStarted { get => _dialogueFlag; set => _dialogueFlag = value; }
    public bool DialogueIsBeenWritting { get => _dialogueIsBeenWritting; }
    protected List<string> Sentences { get => sentences; set => sentences = value; }

    protected virtual void Start()
    {
        this._hasSoundEffect = this.SxEffect != null;
        if (this._hasSoundEffect) this._sxEffect = this.SxEffect;
        this.dialogueText.text = "";
        this.canvas = this.GetComponent<CanvasGroup>();
        if (this.canvas != null) this.canvas.alpha = 0;
    }

    public virtual void StartDialogue(string dialogue)
    {
        this.Sentences.AddRange(Regex.Split(dialogue, @"[@]"));
        this.dialogueText.text = string.Empty;
        this.HasDialogueStarted = true;
        this._currentIndex = 0;
        this._dialogueIsBeenWritting = false;
    }

    public virtual void EndDialogue()
    {
        this.Sentences.Clear();
        this.dialogueText.text = string.Empty;
        this.HasDialogueStarted = false;
        this._currentIndex = 0;
        this._dialogueIsBeenWritting = false;
        if (this.canvas != null) this.canvas.alpha = 0;
    }

    public virtual void NextSentence()
    {
        if (!this.HasDialogueStarted) return;
        if (this._currentIndex <= this.Sentences.Count - 1)
        {
            if (this.canvas != null) this.canvas.alpha = 1;
            this.dialogueText.text = string.Empty;
            StartCoroutine(WriteSentence());
        }
        if (this._currentIndex >= this.Sentences.Count)
            this.EndDialogue();
    }

    private IEnumerator WriteSentence()
    {
        this._dialogueIsBeenWritting = true;
        foreach (char character in Sentences[_currentIndex])
        {
            if (this._hasSoundEffect) AudioManager.Instance.PlaySoundEffect(this._sxEffect);
            this.dialogueText.text += character;
            yield return new WaitForSeconds(this.speed / 100);
        }
        _currentIndex++;
        this._dialogueIsBeenWritting = false;
    }
}
