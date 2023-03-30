using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipUtils : MonoBehaviour
{
    private LookAt _lookAt;

    private void Start()
    {
        if (TryGetComponent<LookAt>(out this._lookAt))
        {
            var target = GameObject.Find("PlayerFollowCamera");
            if (target != null)
                this._lookAt._Target = target.transform;
        }
    }

    public void ShowTootip()
    {
        this.gameObject.SetActive(true);
    }

    public void HideTootip()
    {
        this.gameObject.SetActive(false);
    }
}
