using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Manager")]
    [Space(5)]
    [Range(0, 100)]
    public int BgVolume = 50;

    [Range(0, 100)]
    public int SfxVolume = 50;

    private AudioSource _backgroundMusicSource;
    private AudioSource _sfxSource;

    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
                if (_instance == null)
                {
                    GameObject manager = new GameObject();
                    manager.AddComponent<AudioManager>();
                    manager.name = typeof(AudioManager).ToString();
                    DontDestroyOnLoad(manager);
                }
            }
            _instance.InitSources();
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
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        this.InitSources();
    }

    private void InitSources()
    {
        if (this._backgroundMusicSource == null) this._backgroundMusicSource = InstantiateAudioSource("BGSource");
        this._backgroundMusicSource.volume = ((float)this.BgVolume) / 100f;
        this._backgroundMusicSource.loop = true;
        if (this._sfxSource == null) this._sfxSource = InstantiateAudioSource("SFXSource");
        this._sfxSource.volume = ((float)this.SfxVolume) / 100f;
    }

    private AudioSource InstantiateAudioSource(string name)
    {
        GameObject audioSource = new GameObject();
        audioSource.name = name;
        audioSource.transform.SetParent(this.transform);
        return audioSource.AddComponent<AudioSource>();
    }

    public void StartPlayingMusic(AudioClip clip)
    {
        if (this._backgroundMusicSource == null) return;
        if (this._backgroundMusicSource.isPlaying) this.StopPlayingMusic();
        this._backgroundMusicSource.clip = clip;
        this._backgroundMusicSource.Play();
    }

    public void StopPlayingMusic()
    {
        if (this._backgroundMusicSource == null) return;
        this._backgroundMusicSource.Stop();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        if (this._sfxSource == null) return;
        this._sfxSource.clip = clip;
        this._sfxSource.Play();
    }
}
