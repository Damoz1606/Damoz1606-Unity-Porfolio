using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Slider Slider;
    public Button Button;
    public int Scene;

    private Slider _slider;
    private Button _button;
    private int _scene;
    private AsyncOperation asyncLoad;
    private PresentationController _presentation;
    private bool _hasPresentation = false;

    private void Start()
    {
        this._slider = this.Slider;
        this._button = this.Button;
        this._scene = this.Scene;
        this._hasPresentation = this.TryGetComponent<PresentationController>(out this._presentation);
        this._button.interactable = false;
        this._button.gameObject.SetActive(false);
        this._slider.gameObject.SetActive(true);
        if (!this._hasPresentation) throw new System.Exception("Please set a Presentation Controller");
        this.LoadScene();
    }

    public void LoadScene()
    {
        asyncLoad = SceneManager.LoadSceneAsync(this._scene);
        asyncLoad.allowSceneActivation = false;
    }

    private void Update()
    {
        if (asyncLoad.progress >= 0.9f)
        {
            this._slider.gameObject.SetActive(false);
            this._button.gameObject.SetActive(true);
            if (this._presentation.DialogueIsBeenWritting) return;
            this._button.interactable = true;
        }
    }

    public void NextScene()
    {
        if (asyncLoad.progress >= 0.9f)
        {
            asyncLoad.allowSceneActivation = true;
        }
    }
}
