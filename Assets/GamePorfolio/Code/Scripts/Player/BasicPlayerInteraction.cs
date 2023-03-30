using UnityEngine;

public class BasicPlayerInteraction : MonoBehaviour
{
    [Header("Interaction Values")]
    public LayerMask interactLayers;
    public bool canInteract;

    [SerializeField] protected _AInteractableObject _currentInteraction;

    protected PlayerInputSystem _input;

    private void Start()
    {
        this._input = GetComponent<PlayerInputSystem>();
    }

    private void Update()
    {
        InteractWithObject();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (this.canInteract) this.EnableInteractWithObject(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.canInteract) this.DisableInteractWithObject(other);
    }

    public virtual void InteractWithObject()
    {
        if (!this._input.interact || !this.canInteract || this._currentInteraction == null)
        {
            this._input.interact = false;
            return;
        }
        this._currentInteraction.Interact();
        this._input.interact = false;
    }

    public virtual void EnableInteractWithObject(Collider trigger)
    {
        var bodyLayerMask = 1 << trigger.gameObject.layer;
        if ((bodyLayerMask & this.interactLayers.value) == 0) return;

        this._currentInteraction = trigger.GetComponent<_AInteractableObject>();
    }

    public virtual void DisableInteractWithObject(Collider trigger)
    {
        if (this._currentInteraction == null) return;
        this._currentInteraction = null;
        this._input.interact = false;
    }
}