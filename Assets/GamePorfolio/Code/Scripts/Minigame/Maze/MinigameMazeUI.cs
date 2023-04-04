using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameMazeUI : MonoBehaviour
{
    public GameObject WelcomeScreen;
    public GameObject LevelScreen;
    public GameObject WinnerScreen;
    public GameObject GameOverScreen;

    private void Start()
    {
        this.DisableUI();
    }

    private void OnEnable()
    {
        MinigameMazeEvents.Instance.OnEnableMinigame += this.InitWelcome;
        MinigameMazeEvents.Instance.OnStartMinigame += this.InitLevel;
        MinigameMazeEvents.Instance.OnCompleteMinigame += this.InitWinner;
        MinigameMazeEvents.Instance.OnGameOverMinigame += this.InitGameOver;
        MinigameMazeEvents.Instance.OnDisableMinigame += this.DisableUI;
    }

    private void OnDisable()
    {
        MinigameMazeEvents.Instance.OnEnableMinigame -= this.InitWelcome;
        MinigameMazeEvents.Instance.OnStartMinigame -= this.InitLevel;
        MinigameMazeEvents.Instance.OnCompleteMinigame -= this.InitWinner;
        MinigameMazeEvents.Instance.OnGameOverMinigame -= this.InitGameOver;
        MinigameMazeEvents.Instance.OnDisableMinigame -= this.DisableUI;
    }

    public void InitWelcome()
    {
        WelcomeScreen.SetActive(true);
        LevelScreen.SetActive(false);
        WinnerScreen.SetActive(false);
        GameOverScreen.SetActive(false);
    }

    public void InitLevel()
    {
        WelcomeScreen.SetActive(false);
        LevelScreen.SetActive(true);
        WinnerScreen.SetActive(false);
        GameOverScreen.SetActive(false);
    }

    public void InitWinner()
    {
        WelcomeScreen.SetActive(false);
        LevelScreen.SetActive(false);
        WinnerScreen.SetActive(true);
        GameOverScreen.SetActive(false);
    }

    public void InitGameOver()
    {
        WelcomeScreen.SetActive(false);
        LevelScreen.SetActive(false);
        WinnerScreen.SetActive(false);
        GameOverScreen.SetActive(true);
    }

    public void DisableUI()
    {
        WelcomeScreen.SetActive(false);
        LevelScreen.SetActive(false);
        WinnerScreen.SetActive(false);
        GameOverScreen.SetActive(false);
    }
}
