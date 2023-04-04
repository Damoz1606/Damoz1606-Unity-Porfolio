using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipUtils : MonoBehaviour
{
    private LookAt _lookAt;

    protected virtual void Start()
    {
        bool flag = TryGetComponent<LookAt>(out this._lookAt);
        if (!flag) return;
        var target = GameObject.Find("PlayerCamera");
        if (target != null)
            this._lookAt.Target = target.transform;
    }

    public virtual void ShowTootip()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideTootip()
    {
        this.gameObject.SetActive(false);
    }
}
