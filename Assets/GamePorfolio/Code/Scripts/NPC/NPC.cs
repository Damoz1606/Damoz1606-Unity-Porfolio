using Cinemachine;
using UnityEditor;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Space(10)]
    [Header("NPC Values")]

    [TextArea(5, 10)]
    public string Text;

    private DialogueController dialogue;
    private string text;
    private _AInteractableObject _interaction;

    public string TextMessage { get => text; set => text = value; }

    private void Start()
    {
        this.TextMessage = this.Text;
        
        this.dialogue = this.GetComponentInChildren<DialogueController>();
        if (this.dialogue == null) throw new System.Exception("You need to have a Dialogue Controller in child");

        this._interaction = this.GetComponentInChildren<_AInteractableObject>();
        if (this.dialogue == null) throw new System.Exception("You need to have a Inrectable Object in child");

    }

    public void DisableInteraction()
    {
        this.dialogue.EndDialogue();
    }

    public void EnableInteraction()
    {
        this.dialogue.StartDialogue(this.TextMessage);
    }

    public void Interact()
    {
        if (this.dialogue.DialogueIsBeenWritting) return;
        if (this.dialogue.HasDialogueStarted)
        {
            this._interaction.Player.BlockMovement = true;
            this.dialogue.NextSentence();
        }
        if (!this.dialogue.HasDialogueStarted)
        {
            this._interaction.Player.BlockMovement = false;
            this.dialogue.EndDialogue();
        }
    }
}
