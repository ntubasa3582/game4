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
        //ESCキーを押したらScene上のオブジェクトが止まり、オーディオウィンドウを開く
        if (Input.GetButtonDown("Cancel"))
        {
            _pauseFlg = !_pauseFlg;
            OnPauseResume(_pauseFlg);
        }
        //SPACEキーが押されたら生成されたオブジェクトを削除してボールを初期位置に戻す
        if (Input.GetButtonDown("Jump"))
        {
            OnResetScene();
        }
    }


}
