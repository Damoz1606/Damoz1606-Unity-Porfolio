using System.Collections;
using TMPro;
using UnityEngine;

public class GenericTooltipUtils : TooltipUtils
{

    [Header("Tooltip message")]
    public string Text;
    public float TimeToHide = 5f;

    private TextMeshPro _textMesh;
    private float _timeToHide;

    private void Awake() {
        this._timeToHide = this.TimeToHide;
    }

    protected override void Start()
    {
        base.Start();
        var textTooltip = this.GetComponentInChildren<TextMeshPro>();
        if (textTooltip == null) throw new System.Exception("Set a TextMeshPro in children");
        textTooltip.text = this.Text;
    }

    public override void HideTootip()
    {
        StartCoroutine(this.HideTooltipCoroutine());
    }

    public override void ShowTootip()
    {
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