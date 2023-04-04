using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Version : MonoBehaviour
{
    private TMPro.TextMeshProUGUI _version;

    private void Awake()
    {
        this._version = GetComponent<TMPro.TextMeshProUGUI>();
        if (!this._version)
            this._version = GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }

    private void Start()
    {
        this._version.text = Application.version;
    }
}
