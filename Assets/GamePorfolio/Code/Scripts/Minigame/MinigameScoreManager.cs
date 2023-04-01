using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameScoreManager : MonoBehaviour
{
    public List<TextMeshProUGUI> _scoreTexts;

    private int _currentScore = 0;

    private void OnEnable()
    {
        this._currentScore = 0;
        this.UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        this._currentScore += score;
        this._scoreTexts.ForEach(element =>
        {
            element.text = $"{this._currentScore}";
        });
    }

}
