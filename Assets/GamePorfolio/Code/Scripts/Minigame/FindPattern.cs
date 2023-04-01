using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FindPattern : MonoBehaviour
{
    [SerializeField]
    [Range(0, 5)]
    private float _timeBetweenPatternButtons = 1;
    [SerializeField]
    private List<Pattern> _patterns;

    private int _currentPattern;
    private List<int> _lastPatterns = new List<int>();
    private List<string> _playedPattern = new List<string>();
    [SerializeField] private List<PatternButton> _buttons = new List<PatternButton>();
    private Dictionary<string, PatternButton> _buttonDictionary = new Dictionary<string, PatternButton>();


    private void Awake()
    {
        this._buttons.AddRange(this.GetComponentsInChildren<PatternButton>());
        this.InitDictionary();
    }

    private void OnEnable()
    {
        MinigameFindPatternEventManager.Instance.OnStartPattern += this.StartPattern;
        MinigameFindPatternEventManager.Instance.OnNextPattern += this.NextPattern;
        MinigameFindPatternEventManager.Instance.OnPlayedButton += this.PlayedPattern;
        
    }

    private void OnDisable()
    {
        MinigameFindPatternEventManager.Instance.OnStartPattern -= this.StartPattern;
        MinigameFindPatternEventManager.Instance.OnNextPattern -= this.NextPattern;
        MinigameFindPatternEventManager.Instance.OnPlayedButton -= this.PlayedPattern;
    }

    private void InitDictionary()
    {
        this._buttonDictionary.Clear();
        this._buttons.ForEach(element =>
        {
            this._buttonDictionary.Add(element.gameObject.name, element);
        });
    }

    public void StartPattern()
    {
        this._playedPattern.Clear();
        this._lastPatterns.Clear();
        StartCoroutine(this.StartPatternCoroutine());
    }

    private IEnumerator StartPatternCoroutine()
    {
        yield return new WaitForSeconds(1);
        this.SelectPattern();
    }

    public void NextPattern()
    {
        if (this._lastPatterns.Count >= this._patterns.Count) return;
        this._playedPattern.Clear();
        this.SelectPattern();
    }

    private void SelectPattern()
    {
        do
        {
            this._currentPattern = UnityEngine.Random.Range(0, this._patterns.Count);
        } while (this._lastPatterns.Contains(this._currentPattern));

        StartCoroutine(SelectPatternCoroutine());
        this._lastPatterns.Add(this._currentPattern);
    }


    private IEnumerator SelectPatternCoroutine()
    {
        foreach (var element in this._patterns[this._currentPattern].patterns)
        {
            PatternButton auxiliarButton = null;
            this._buttonDictionary.TryGetValue(element.ToString(), out auxiliarButton);
            if (auxiliarButton != null)
            {
                auxiliarButton.PatternActive();
                yield return new WaitForSeconds(_timeBetweenPatternButtons);
            }
        }
        this._buttons.ForEach(element =>
        {
            element.HasGameStarted = true;
        });
    }

    public void PlayedPattern(string name)
    {

        if (this._playedPattern.Count == 0 && this._patterns[this._currentPattern].patterns[0].ToString().Equals(name))
            this._playedPattern.Add(name);
        else if (this._patterns[this._currentPattern].patterns[this._playedPattern.Count].ToString().Equals(name))
            this._playedPattern.Add(name);
        else
        {
            this._playedPattern.Clear();
            MinigameFindPatternEventManager.Instance.OnPatternGameOver.Invoke();
        }
        if (this._playedPattern.Count >= this._patterns[this._currentPattern].patterns.Count)
        {
            this._playedPattern.Clear();
            MinigameFindPatternEventManager.Instance.OnPatternComplete.Invoke();
        }


    }

    public enum PatternSequences
    {
        TOP_LEFT,
        TOP_RIGHT,
        RIGHT,
        CENTER,
        LEFT,
        BOTTOM_LEFT,
        BOTTOM_RIGHT,
    }

    [Serializable]
    public class Pattern
    {
        public List<PatternSequences> patterns;
    }
}
