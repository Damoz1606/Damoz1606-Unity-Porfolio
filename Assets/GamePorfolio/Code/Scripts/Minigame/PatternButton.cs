using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PatternButton : MonoBehaviour
{
    [SerializeField]
    public Color Color;

    [SerializeField]
    [Range(0, 255)]
    public int NonClickedAlpha = 100;
    [SerializeField]
    [Range(0, 255)]
    public int ClickedAlpha = 255;
    [SerializeField]
    public AudioClip Click;

    private bool _hasGameStarted = false;
    private bool _hasBeenClicked = false;

    private float _nonClickedAlpha;
    private float _clickedAlpha;
    private float _patternActiveTime = 0.75f;

    private Button _button;

    private Image _imageBackground;

    private AudioClip _click;

    public bool HasGameStarted { get => _hasGameStarted; set => _hasGameStarted = value; }

    private void Awake()
    {
        this._nonClickedAlpha = NonClickedAlpha;
        this._clickedAlpha = ClickedAlpha;
        this._click = this.Click;
    }

    private void Start()
    {
        this._button = GetComponentInChildren<Button>();
        var tempImages = GetComponentsInChildren<Image>();
        foreach (var item in tempImages)
        {
            item.color = this.Color;
        }
        if (this._button != null)
        {
            this._imageBackground = this._button.GetComponent<Image>();
            if (this._imageBackground == null) throw new System.Exception("You don't have a button with background");
            this.changeAlpha();
        }
    }

    private void OnEnable()
    {
        if (this._button != null)
            this.changeAlpha();
    }

    public void OnClicked()
    {
        if (!this.HasGameStarted) return;
        if (!this._hasBeenClicked)
        {
            this._hasBeenClicked = true;
            PatternActive();
            MinigameFindPatternEventManager.Instance.OnPlayedButton(this.gameObject.name);
        }
    }

    public void PatternActive()
    {
        StartCoroutine(this.PatternActiveCoroutine());
    }

    private IEnumerator PatternActiveCoroutine()
    {
        AudioSource.PlayClipAtPoint(this._click, Vector3.zero, 1);
        changeAlpha(false);
        yield return new WaitForSeconds(this._patternActiveTime);
        changeAlpha(true);
        this._hasBeenClicked = false;
        yield return null;

    }

    private void changeAlpha(bool transparent = true)
    {
        if (this._imageBackground == null) return;
        var tempColor = this._imageBackground.color;
        tempColor.a = (transparent) ? this._nonClickedAlpha / 255 : this._clickedAlpha / 255;
        this._imageBackground.color = tempColor;
    }
}
