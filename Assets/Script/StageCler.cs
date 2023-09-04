using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageCler : MonoBehaviour
{
    [SerializeField] float _interval = 1;
    [SerializeField] GameObject _spawnGameobject;
    [SerializeField] GameObject _managerGameObject;
    [SerializeField] Canvas _clearCanvas;
    [SerializeField, Tooltip("リセットしたいSceneの名前を入れる")] string _scenename;
    [SerializeField] bool _clearSwich = false;

    private void Start()
    {
        _clearCanvas.enabled = false;
    }
    private void Update()
    {
        if (_clearSwich == false)
        {
            if (Input.GetKeyDown(KeyCode.R)) //Rキーを押したらSceneをリロードできる
            {
                //SceneManager.LoadScene(_scenename);
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
            _spawnGameobject.SetActive(false);
            _managerGameObject.SetActive(false);
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
