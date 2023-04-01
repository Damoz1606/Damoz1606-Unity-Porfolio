using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvent : MonoBehaviour
{
    private static PlayerEvent _instance;

    public static PlayerEvent Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerEvent>();
                if (_instance == null)
                {
                    GameObject manager = new GameObject();
                    manager.AddComponent<PlayerEvent>();
                    manager.name = typeof(PlayerEvent).ToString();
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


    public UnityAction OnBlockMovement;
    public UnityAction OnUnblockMovement;
}
