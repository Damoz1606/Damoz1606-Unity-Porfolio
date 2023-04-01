using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurRenderer : MonoBehaviour
{
    public Camera BlurCamera;
    public Material BlurMaterial;

    private void Start()
    {
        if (this.BlurCamera.targetTexture != null)
            this.BlurCamera.targetTexture.Release();
        this.BlurCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32, 1);
        this.BlurMaterial.SetTexture("_RenTex", this.BlurCamera.targetTexture);
    }
}
