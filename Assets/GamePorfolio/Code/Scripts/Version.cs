using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Version : MonoBehaviour
{
    public TMPro.TextMeshProUGUI _version;

    private void Start()
    {
        bool hasText = TryGetComponent<TMPro.TextMeshProUGUI>(out _version);
        if(!hasText) throw new System.Exception("Set a text MeshPro for a version");
        this._version.text = Application.version;
    }
}
