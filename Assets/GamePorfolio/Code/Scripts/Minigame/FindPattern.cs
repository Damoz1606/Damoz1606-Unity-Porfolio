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
    [SerializeField] private List<Pattern> _patterns;

    private int _currentPattern;
    private List<PatternButton> _buttons;
    private List<int> _lastPatterns = new List<int>();
    private Dictionary<string, PatternButton> _buttonDictionary = new Dictionary<string, PatternButton>();

    private List<string> _playedPattern = new List<string>();

    void Start()
    {
        this._buttons = new List<PatternButton>(this.GetComponentsInChildren<PatternButton>());
        this.InitDictionary();
        StartCoroutine(this.WaitToInitialize());
    }

    private void InitDictionary()
    {

        this._buttons.ForEach(element =>
        {
            this._buttonDictionary.Add(element.gameObject.name, element);
            element.OnPlayedPattern += this.PlayedPattern;
        });
    }

    private IEnumerator WaitToInitialize()
    {
        yield return new WaitForSeconds(0.5f);
        this.SelectPattern();
    }

    private void SelectPattern()
    {
        if (this._lastPatterns.Count >= this._patterns.Count) return;
        this._playedPattern.Clear();
        do
        {
            this._currentPattern = UnityEngine.Random.Range(0, this._patterns.Count);
        } while (this._lastPatterns.Contains(this._currentPattern));

        StartCoroutine(SelectPatternCoroutine());
        this._lastPatterns.Add(this._currentPattern);
        var count = 0;
        foreach (var item in this._patterns[this._currentPattern].patterns)
        {
            Debug.Log($"{count} ${item}");
            count++;
        }
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
            Debug.Log("Game over");
        }
        if (this._playedPattern.Count >= this._patterns[this._currentPattern].patterns.Count)
        {
            this._playedPattern.Clear();
            Debug.Log("You won");
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
