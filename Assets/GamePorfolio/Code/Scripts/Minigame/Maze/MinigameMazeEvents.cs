using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigameMazeEvents : _AMinigameEvent
{
    private static MinigameMazeEvents _instance;

    public static MinigameMazeEvents Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MinigameMazeEvents>();
                if (_instance == null)
                {
                    GameObject manager = FindObjectOfType<MinigameMaze>().gameObject;
                    if (manager == null) throw new System.Exception("There is no MinigameMaze Component");
                    manager.AddComponent<MinigameMazeEvents>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }
}
