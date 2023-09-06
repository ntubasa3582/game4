using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager2D : MonoBehaviour
{
    bool _pauseFlg = false;
    public delegate void Pause(bool isPause);
    public event Action<bool> OnPauseResume; //escキーでPause画面を呼び出す
    public event Action OnResetScene; //SpaceでSceneの初期化をする
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            _pauseFlg = !_pauseFlg;
            OnPauseResume(_pauseFlg);
        }
        if (Input.GetButtonDown("Jump"))
        {
            OnResetScene();
        }
    }
}
