using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CanvasFadeTransition : MonoBehaviour
{
    [SerializeField]
    [Range(0, 5)]
    public float transitionTime = 1;

    [SerializeField]
    public bool fadeOut;
    [SerializeField]
    public bool onStart;

    [SerializeField]
    public UnityEvent BeforeTransition;
    [SerializeField]
    public UnityEvent AfterTransition;


    private float _transitionTime;
    private bool _fadeOut;
    private bool _onStart;
    private CanvasGroup _canvas;

    private void Awake()
    {
        this._fadeOut = this.fadeOut;
        this._onStart = this.onStart;
        this._transitionTime = this.transitionTime;

        this._canvas = GetComponent<CanvasGroup>();
        if (this._canvas != null)
            this._canvas = GetComponentInChildren<CanvasGroup>();
    }

    void Start()
    {
        if (this._onStart)
            this.FadeImage();
    }

    public void FadeImage()
    {
        this.BeforeTransition?.Invoke();

        this._canvas.DOFade((this._fadeOut) ? 0 : 1, this._transitionTime)
        .OnComplete(() => this.AfterTransition?.Invoke());
    }
}
