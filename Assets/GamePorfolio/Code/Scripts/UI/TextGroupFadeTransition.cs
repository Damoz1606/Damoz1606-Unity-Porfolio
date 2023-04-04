using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextGroupFadeTransition : TextGroup
{
    [Header("Transition")]
    [SerializeField]
    [Range(0, 2)]
    public float TimeTransition = 1;


    private bool _transitionComplete;

    private float _timeTransition;

    private List<CanvasGroup> _canvas;


    public bool TransitionComplete { get => _transitionComplete; }

    protected override void Awake()
    {
        base.Awake();
        this._transitionComplete = false;
        this._timeTransition = this.TimeTransition;
        this._canvas = new List<CanvasGroup>();
    }

    protected override void Start()
    {
        base.Start();
        this._transitionComplete = false;
        this._canvas.AddRange(GetComponentsInChildren<CanvasGroup>());
        this._canvas.ForEach(element => element.alpha = 0);
        this.EnableTextByTransition();
    }

    private void OnEnable()
    {
        this._transitionComplete = false;
        this.EnableTextByTransition();
    }

    public void EnableTextByTransition()
    {
        this._canvas.ForEach(element => element.alpha = 0);
        this.EnableTextByTransitionRecursive(0);
    }

    private void EnableTextByTransitionRecursive(int index)
    {
        if (index >= this._canvas.Count)
        {
            this._transitionComplete = true;
            return;
        }

        if (index > 0)
            this._canvas[index - 1]
                .DOFade(0, this._timeTransition / 2)
                .OnComplete(() =>
                    this._canvas[index]
                    .DOFade(1, this.TimeTransition)
                    .OnComplete(() =>
                        EnableTextByTransitionRecursive(index + 1)));
        else
        {
            this._canvas[index]
                .DOFade(1, this.TimeTransition)
                .OnComplete(() =>
                    EnableTextByTransitionRecursive(index + 1));
        }
    }

    public void FadeLastLine()
    {
        if (this._transitionComplete)
            this._canvas[this._canvas.Count - 1].DOFade(0, this._timeTransition / 2);
    }
}
