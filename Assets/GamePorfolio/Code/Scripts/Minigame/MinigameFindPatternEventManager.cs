using UnityEngine;
using UnityEngine.Events;

public class MinigameFindPatternEventManager : MonoBehaviour
{
    private static MinigameFindPatternEventManager _instance;

    public static MinigameFindPatternEventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MinigameFindPatternEventManager>();
                if (_instance == null)
                {
                    GameObject manager = FindObjectOfType<MinigameFindPattern>().gameObject;
                    if (manager == null) throw new System.Exception("There is no MinigameFindPattern Component");
                    manager.AddComponent<MinigameFindPatternEventManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }

    public UnityAction OnStartPattern;
    public UnityAction OnNextPattern;
    public UnityAction OnPatternComplete;
    public UnityAction OnPatternGameOver;
    public UnityAction<string> OnPlayedButton;
}