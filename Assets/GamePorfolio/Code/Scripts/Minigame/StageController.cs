using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    private Image[] stages;

    private int _currentStage;

    private void Awake()
    {
        this._currentStage = 0;
    }

    private void Start()
    {
        stages = GetComponentsInChildren<Image>();
        this.StartStage();
    }

    private void OnEnable()
    {
        this.StartStage();
    }

    public void StartStage()
    {
        if(this.stages.Length <= 0) return; 
        foreach (var item in stages)
        {
            var tempColor = item.color;
            tempColor.a = 150f / 255f;
            item.color = tempColor;
        }
    }

    public void NextStage()
    {
        if (this._currentStage >= this.stages.Length) return;
        var tempColor = stages[this._currentStage].color;
        tempColor.a = 1f;
        stages[this._currentStage].color = tempColor;
        this._currentStage++;
    }
}
