using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkInteractableObject : _AInteractableObject
{
    [Header("Link values")]
    public string URL;

    private string _url;

    private void Start()
    {
        if (this.URL == string.Empty || this.URL == null)
            throw new System.Exception("Please assign a url");
        this._url = this.URL;
    }

    public override void DisableInteraction()
    {
        // throw new System.NotImplementedException();
    }

    public override void EnableInteraction()
    {
        // throw new System.NotImplementedException();
    }

    public override void Interact()
    {
        Application.OpenURL(this._url);
    }
}
