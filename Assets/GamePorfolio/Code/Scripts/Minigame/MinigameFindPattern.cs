using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigameFindPattern : MonoBehaviour
{
    public GameObject WelcomeCanvas;
    public GameObject PatternCanvas;
    public GameObject GameOverCanvas;
    public GameObject NextStageCanvas;
    public GameObject WinnerCanvas;

    private MinigameScoreManager _scoreManager;
    private int _currentStage;
    private int _maxStages;
    private bool _hasStarted;
    private FindPattern _findPattern;

    private void Awake()
    {
        this.InitVariables();
    }

    private void Start()
    {
        this._scoreManager = this.GetComponentInChildren<MinigameScoreManager>();
        if (this._scoreManager == null) throw new System.Exception("Please set a MinigameScoreManager before start");
    }

    private void OnEnable()
    {
        MinigameFindPatternEventManager.Instance.OnPatternComplete += this.OnCompleteStage;
        MinigameFindPatternEventManager.Instance.OnPatternGameOver += this.OnGameover;
        this.InitVariables();
    }

    private void OnDisable()
    {
        MinigameFindPatternEventManager.Instance.OnPatternComplete -= this.OnCompleteStage;
        MinigameFindPatternEventManager.Instance.OnPatternGameOver -= this.OnGameover;
    }

    private void InitVariables()
    {
        this._currentStage = 0;
        this._maxStages = 3;
        this._hasStarted = false;
    }

    public void EnableMinigame()
    {
        PlayerEvent.Instance.OnBlockMovement();
        this.gameObject.SetActive(true);
        this.WelcomeCanvas.SetActive(true);
        this.PatternCanvas.SetActive(false);
        this.NextStageCanvas.SetActive(false);
        this.WinnerCanvas.SetActive(false);
        this.GameOverCanvas.SetActive(false);
    }

    public void PatternMinigame()
    {
        this.WelcomeCanvas.SetActive(false);
        this.PatternCanvas.SetActive(true);
        this.NextStageCanvas.SetActive(false);
        this.WinnerCanvas.SetActive(false);
        this.GameOverCanvas.SetActive(false);
        this.StartPattern();
    }

    public void NextStageMinigame()
    {
        this.WelcomeCanvas.SetActive(false);
        this.PatternCanvas.SetActive(false);
        this.NextStageCanvas.SetActive(true);
        this.WinnerCanvas.SetActive(false);
        this.GameOverCanvas.SetActive(false);
    }

    public void WinnerMinigame()
    {
        this.WelcomeCanvas.SetActive(false);
        this.PatternCanvas.SetActive(false);
        this.NextStageCanvas.SetActive(false);
        this.WinnerCanvas.SetActive(true);
        this.GameOverCanvas.SetActive(false);
    }

    public void GameOverMinigame()
    {
        this.WelcomeCanvas.SetActive(false);
        this.PatternCanvas.SetActive(false);
        this.NextStageCanvas.SetActive(false);
        this.WinnerCanvas.SetActive(false);
        this.GameOverCanvas.SetActive(true);
    }

    public void DisableMinigame()
    {
        gameObject.SetActive(false);
        PlayerEvent.Instance.OnUnblockMovement();
    }

    private void StartPattern()
    {
        if (this._currentStage < this._maxStages)
        {
            if (!this._hasStarted)
            {
                MinigameFindPatternEventManager.Instance.OnStartPattern();
                this._hasStarted = true;
            }
            else
            {
                MinigameFindPatternEventManager.Instance.OnNextPattern();
                this._hasStarted = true;
            }
            this._currentStage++;
        }
    }

    private void OnCompleteStage()
    {
        this._scoreManager.UpdateScore(100);
        if (this._currentStage < this._maxStages)
            this.NextStageMinigame();
        else
            this.WinnerMinigame();
    }

    private void OnGameover()
    {
        this.GameOverMinigame();
    }
}
