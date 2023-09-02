using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllor : MonoBehaviour
{
    PauseManager2D _pauseManager = default;
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        _pauseManager = GameObject.FindObjectOfType<PauseManager2D>();
        _audioSource = GetComponent<AudioSource>();
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
        _audioSource.Pause();
    }

    public void Resume()
    {
        _audioSource.Play();
    }
}
