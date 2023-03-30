using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip Music;

    void Start()
    {
        AudioManager.Instance.StartPlayingMusic(this.Music);
    }
}
