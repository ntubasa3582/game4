using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectControllor : MonoBehaviour
{
    [SerializeField] float _interval;
    PauseManager2D _pauseManager = default;
    Rigidbody2D _rb;
    Vector3 _angularVelocity;
    Vector3 _velocity;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, _interval);
        _pauseManager = GameObject.FindObjectOfType<PauseManager2D>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void OnEnable()
    {
        _pauseManager.OnPauseResume += PauseResume;
        _pauseManager.OnResetScene += ResetScene;
    }

    public void OnDisable()
    {
        _pauseManager.OnPauseResume -= PauseResume;
        _pauseManager.OnResetScene -= ResetScene;
    }

    void ResetScene()
    {
        Destroy(this.gameObject);
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
       // _angularVelocity = _rb.angularVelocity;
        _velocity = _rb.velocity;
        _rb.Sleep();

    }

    public void Resume()
    {
        _rb.WakeUp();
        _rb.velocity = _velocity;
    }
}
