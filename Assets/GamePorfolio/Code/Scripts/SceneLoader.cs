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

    private int _scene;
    private Slider _slider;
    private Button _button;
    private AsyncOperation asyncLoad;
    private TextGroupFadeTransition _textGroupTransition;

    private void Awake()
    {
        this._slider = this.Slider;
        this._button = this.Button;
        this._scene = this.Scene;
        this._textGroupTransition = GetComponentInChildren<TextGroupFadeTransition>();
    }

    private void Start()
    {

        this._button.interactable = false;
        this._button.gameObject.SetActive(false);
        this._slider.gameObject.SetActive(true);
        this.LoadScene();
        if (!this._textGroupTransition) throw new System.Exception("Please set a TextGroupFadeTransition");
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
            if (!this._textGroupTransition.TransitionComplete) return;
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
