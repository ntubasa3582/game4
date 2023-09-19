using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager2D : MonoBehaviour
{
    bool _pauseFlg = false;
    public delegate void Pause(bool isPause);
    public event Action<bool> OnPauseResume; //escƒL[‚ÅPause‰æ–Ê‚ğŒÄ‚Ño‚·
    public event Action OnResetScene; //Space‚ÅScene‚Ì‰Šú‰»‚ğ‚·‚é
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
