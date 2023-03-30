using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _AInteractableObject : MonoBehaviour
{
    [Header("Interactable Object Values")]
    [SerializeField] public LayerMask _playerLayer;

    private PlayerController _player;

    public PlayerController Player { get => _player; }

    public abstract void EnableInteraction();
    public abstract void DisableInteraction();
    public abstract void Interact();


    protected virtual void OnTriggerEnter(Collider other)
    {
        var bodyLayerMask = 1 << other.gameObject.layer;
        if ((bodyLayerMask & this._playerLayer.value) == 0) return;

        this._player = other.GetComponent<PlayerController>();

        this.EnableInteraction();
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        this.DisableInteraction();
        if (this._player == default) return;
        this._player = default;
    }
}
