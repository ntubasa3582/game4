using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllor : MonoBehaviour
{
    //DDOLで音のボリュームを引き継ぐ
    PauseManager2D _pauseManager = default;
    AudioSource _audioSource;
    static bool _saveSwich = false;
    public static float _volumeStorage = 0;
    // Start is called before the first frame update
    void Awake()
    {
        _pauseManager = GameObject.FindObjectOfType<PauseManager2D>();
        _audioSource = GetComponent<AudioSource>();
        if (_saveSwich == true)
        {
            //Debug.Log(_saveSwich);
            _audioSource.volume = _volumeStorage;
            _saveSwich = false;
        }
    }

    private void Update()
    {
        _volumeStorage = _audioSource.volume;
        Debug.Log(_volumeStorage);
    }

    public void OnEnable()
    {
        _pauseManager.OnPauseResume += PauseResume;
    }

    public void OnDisable()
    {
        _pauseManager.OnPauseResume -= PauseResume;
    }

    void PauseResume(bool isPause)
    {
        if (isPause)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Pause() //escが押されたらアニメーションスピードを0にする
    {
        //_audioSource.Pause();
    }

    public void Resume()
    {
        //_audioSource.Play();
    }

    public void SaveAudio()
    {
        _saveSwich = true;
        _volumeStorage = _audioSource.volume;
        Debug.Log(_volumeStorage);
    }
}
