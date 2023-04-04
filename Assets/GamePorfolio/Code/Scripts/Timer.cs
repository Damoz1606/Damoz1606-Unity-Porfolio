using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] public float TargetTime;
    [SerializeField] public UnityEvent OnTimerEnded;

    private float _targetTime;
    private float _currentTime;
    private bool _hasTimerStarted;

    private TextMeshProUGUI _timerText;

    private void Awake()
    {
        this._targetTime = this.TargetTime;
        this._hasTimerStarted = false;
    }

    private void Start()
    {
        this._timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!this._hasTimerStarted) return;
        if (this._currentTime > 0.0f)
        {
            this._currentTime -= Time.deltaTime;
            this._currentTime = this._currentTime < 0 ? 0 : this._currentTime;
            this._timerText.text = TimeUtils.SecondToMinutes((int)this._currentTime);
        }
        if (this._currentTime <= 0.0f) this.StopTimer();
    }

    public void InitTimer()
    {
        this._hasTimerStarted = true;
        this._currentTime = this._targetTime;
    }

    public void StopTimer()
    {
        this._hasTimerStarted = false;
        this._currentTime = this._targetTime;
        this._timerText.text = TimeUtils.SecondToMinutes((int)this._currentTime);
        this.OnTimerEnded?.Invoke();
    }
}
