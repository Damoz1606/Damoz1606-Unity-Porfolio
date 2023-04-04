using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Maze : MonoBehaviour
{
    public UnityEvent OnEnableMaze;
    public UnityEvent OnExit;
    public UnityEvent OnEnter;

    private void OnEnable()
    {
        this.OnEnableMaze?.Invoke();
    }

    public void Enter()
    {
        this.OnEnter.Invoke();
    }

    public void Exit()
    {
        this.OnExit.Invoke();
    }
}
