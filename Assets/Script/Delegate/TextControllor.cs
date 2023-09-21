using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControllor : MonoBehaviour
{
    Animator _animator;
    PauseManager2D _pauseManager = default;
    //float _speedStorage = 0;
    // Start is called before the first frame update
    void Awake()
    {
        _pauseManager = GameObject.FindObjectOfType<PauseManager2D>();
        _animator = GetComponent<Animator>();
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

    public void Pause()
    {
        _animator.speed = 0;
    }

    public void Resume()
    {
        _animator.speed = 1;
        Debug.Log("2");
    }
}
