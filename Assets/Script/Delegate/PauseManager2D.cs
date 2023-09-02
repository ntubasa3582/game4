using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager2D : MonoBehaviour
{
    bool _pauseFlg = false;
    public delegate void Pause(bool isPause);
    Pause _onPauseResume = default;
    // Start is called before the first frame update
    //public Pause OnPauseResume { get => _onPauseResume; set => _onPauseResume = value; }

    public Pause OnPauseResume
    {
        get { return _onPauseResume; }
        set { _onPauseResume = value; }
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseResume();
        }
    }

    void PauseResume()
    {
        _pauseFlg = !_pauseFlg;
        _onPauseResume(_pauseFlg);
    }
}
