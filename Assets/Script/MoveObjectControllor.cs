using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObjectControllor : MonoBehaviour
{
    /// <summary></summary>
    [SerializeField] string _boolName;
    PauseManager2D _pauseManager = default;
    Animator _anim = default;
    // Start is called before the first frame update
    void Awake()
    {
        _pauseManager = GameObject.FindObjectOfType<PauseManager2D>();
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _pauseManager.OnResetScene += ResetScene;
    }

    private void OnDisable()
    {
        _pauseManager.OnResetScene -= ResetScene;
    }

    void ResetScene()
    {
        DeActivate();
        Debug.Log("aaa");
    }

    public void Activate()
    {
        _anim.SetBool("isOpen", true);
    }

    void DeActivate()
    {
        _anim.SetBool(_boolName, false);
    }
}
