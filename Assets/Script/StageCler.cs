using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageCler : MonoBehaviour
{
    [SerializeField] float _interval = 1;
    [SerializeField] Canvas _clearCanvas;
    [SerializeField, Tooltip("���Z�b�g������Scene�̖��O������")] string _scenename;
    [SerializeField] bool _clearSwich = false;

    private void Start()
    {
        _clearCanvas.enabled = false;
    }
    private void Update()
    {
        if (_clearSwich == false)
        {
            if (Input.GetKeyDown(KeyCode.R)) //R�L�[����������Scene�������[�h�ł���
            {
                SceneManager.LoadScene(_scenename);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _clearCanvas.enabled = true;
            _clearSwich = true;
            StartCoroutine("SceneChange");
        }
    }
    public void SceneMove()
    {
        //SceneManager.LoadScene("StageSelect");
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(_interval);
        SceneMove();
        
    }
}
