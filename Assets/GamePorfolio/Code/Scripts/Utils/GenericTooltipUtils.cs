using System.Collections;
using TMPro;
using UnityEngine;

public class GenericTooltipUtils : TooltipUtils
{

    [Header("Tooltip message")]
    public string text;
    public float TimeToHide = 5f;

    private string _text;
    private float _timeToHide;
    private TextMeshPro _textMesh;

    public string Text { get => _text; set => _text = value; }

    private void Awake()
    {
        this.Text = this.text;
        this._timeToHide = this.TimeToHide;
        this._textMesh = this.GetComponentInChildren<TextMeshPro>();
        if (this._textMesh == null) throw new System.Exception("Set a TextMeshPro in children");
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void HideTootip()
    {
        StartCoroutine(this.HideTooltipCoroutine());
    }

    public override void ShowTootip()
    {
        this._textMesh.text = this.Text;
        base.ShowTootip();
        this.HideTootip();
    }

    private IEnumerator HideTooltipCoroutine()
    {
        yield return new WaitForSeconds(this._timeToHide);
        this.gameObject.SetActive(false);
        yield return null;
    }
}