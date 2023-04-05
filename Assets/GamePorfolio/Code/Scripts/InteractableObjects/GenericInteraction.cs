using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericInteraction : _AInteractableObject
{
    [Space(10)]
    [Header("Generic Interaction")]
    [Space(5)]
    [SerializeField] private UnityEvent OnEnableInteraction;
    [SerializeField] private UnityEvent OnDisableInteraction;
    [SerializeField] private UnityEvent OnInteraction;

    public override void DisableInteraction()
    {
        this.OnDisableInteraction?.Invoke();
    }

    public override void EnableInteraction()
    {
        this.OnEnableInteraction?.Invoke();
    }

    public override void Interact()
    {
        this.OnInteraction?.Invoke();
    }
}
