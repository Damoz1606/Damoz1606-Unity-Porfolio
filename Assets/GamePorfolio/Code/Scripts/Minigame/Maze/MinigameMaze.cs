using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigameMaze : _AMinigame
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    private bool _completed;

    private void Awake()
    {
        this._completed = false;
    }

    private void Start()
    {
    }

    public void EnterToMaze()
    {
        this.OnEnter?.Invoke();
    }

    public void ExitFromMaze()
    {
        this.OnExit?.Invoke();
    }

    public override void EnableMinigame()
    {
        MinigameMazeEvents.Instance.OnEnableMinigame?.Invoke();
    }

    public override void DisableMinigame()
    {
        MinigameMazeEvents.Instance.OnDisableMinigame?.Invoke();
    }

    public override void StartMinigame()
    {
        this._completed = false;
        MinigameMazeEvents.Instance.OnStartMinigame?.Invoke();
    }

    public override void CompleteMinigame()
    {
        this._completed = true;
        this.ExitFromMaze();
        MinigameMazeEvents.Instance.OnCompleteMinigame?.Invoke();
    }

    public override void GameOverMinigame()
    {
        if (this._completed) return;
        this.ExitFromMaze();
        MinigameMazeEvents.Instance.OnGameOverMinigame?.Invoke();
    }
}
