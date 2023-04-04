using UnityEngine;
using UnityEngine.Events;

public class _AMinigameEvent : MonoBehaviour
{
    public UnityAction OnEnableMinigame;
    public UnityAction OnDisableMinigame;
    public UnityAction OnStartMinigame;
    public UnityAction OnCompleteMinigame;
    public UnityAction OnGameOverMinigame;
}