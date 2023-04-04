using UnityEngine;

public abstract class _AMinigame : MonoBehaviour
{
    public abstract void EnableMinigame();
    public abstract void DisableMinigame();
    public abstract void StartMinigame();
    public abstract void GameOverMinigame();
    public abstract void CompleteMinigame();
}