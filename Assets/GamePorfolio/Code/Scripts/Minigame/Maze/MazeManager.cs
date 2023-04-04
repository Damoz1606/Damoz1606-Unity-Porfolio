using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _mazes = new List<GameObject>();

    private int _currentIndex;

    private void Awake()
    {
        this._currentIndex = 0;
    }

    private void OnEnable()
    {
        this._currentIndex = 0;
        MinigameMazeEvents.Instance.OnStartMinigame += this.StartMazeMinigame;
        MinigameMazeEvents.Instance.OnGameOverMinigame += this.EndMazeMinigame;
        MinigameMazeEvents.Instance.OnCompleteMinigame += this.EndMazeMinigame;
    }

    private void OnDisable() {
        MinigameMazeEvents.Instance.OnStartMinigame -= this.StartMazeMinigame;
        MinigameMazeEvents.Instance.OnGameOverMinigame -= this.EndMazeMinigame;
        MinigameMazeEvents.Instance.OnCompleteMinigame -= this.EndMazeMinigame;
    }

    public void StartMazeMinigame()
    {
        this._currentIndex = Random.Range(0, _mazes.Count);
        this._mazes.ForEach(maze => maze.SetActive(false));
        this._mazes[this._currentIndex].SetActive(true);
    }

    public void NextMazeMinigame()
    {
        this._currentIndex++;
        if (this._currentIndex >= this._mazes.Count) this._currentIndex = 0;
        this._mazes.ForEach(maze => maze.SetActive(false));
        this._mazes[this._currentIndex].SetActive(true);
    }

    public void EndMazeMinigame()
    {
        this._mazes.ForEach(maze => maze.SetActive(false));
    }

}
