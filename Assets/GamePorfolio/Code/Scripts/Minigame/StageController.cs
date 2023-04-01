using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    private List<Image> stages = new List<Image>();

    private int _currentStage;

    private void Awake()
    {
        this._currentStage = 0;
        stages.AddRange(GetComponentsInChildren<Image>());
    }

    private void Start()
    {
        this.StartStage();
    }

    private void OnEnable()
    {
        this.StartStage();
    }

    public void StartStage()
    {
        if (this.stages.Count <= 0) return;
        foreach (var item in stages)
        {
            var tempColor = item.color;
            tempColor.a = 150f / 255f;
            item.color = tempColor;
        }
    }

    public void NextStage()
    {
        if (this._currentStage >= this.stages.Count) return;
        var tempColor = stages[this._currentStage].color;
        tempColor.a = 1f;
        stages[this._currentStage].color = tempColor;
        this._currentStage++;
    }
}
