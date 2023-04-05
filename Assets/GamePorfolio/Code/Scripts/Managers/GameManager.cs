using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Settings;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public UnityEvent OnAwake;
    [SerializeField]
    public UnityEvent OnStart;

    private bool _gameHasStarted;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject manager = new GameObject();
                    manager.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    public bool GameHasStarted { get => _gameHasStarted; set => _gameHasStarted = value; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;

        this.GameHasStarted = false;

        this.OnAwake?.Invoke();
    }

    private void Start()
    {
        this.SetLocale(PlayerPrefs.GetInt(PlayerPrefKeys.LOCATION_KEY, 0));
        this.OnStart?.Invoke();
    }

    private IEnumerator SetLocale(int localeID)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        PlayerPrefs.SetInt(PlayerPrefKeys.LOCATION_KEY, localeID);
    }
}
