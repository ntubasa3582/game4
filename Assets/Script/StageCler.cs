using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageCler : MonoBehaviour
{
    [SerializeField] GameObject _spawnGameobject;
    [SerializeField] GameObject _managerGameObject;
    [SerializeField] Canvas _clearCanvas;
    [SerializeField] GameObject _nextButton;
    GameObject[] _posObj;
    AudioSource _audioSource;
    AudioClip _clip;
    bool _posSwich= false;
    bool _bgmSwich= true;
    private void Awake()
    {
        Invoke("Swich", 0.1f);
        SceneManager.sceneLoaded += OnSceneLoaded;
        _audioSource = GetComponent<AudioSource>();
        _clip = GetComponent<AudioClip>();
        _clearCanvas.enabled = false;
        _posObj = GameObject.FindGameObjectsWithTag("PosGoal");//PosGoalのタグが付いているゲームオブジェクトを探してくる
        if (_posObj != null)
        {
            if (SceneManager.GetActiveScene().name != "Title")
            {
                this.transform.position = _posObj[0].transform.position;
                //探してきたゲームオブジェクトの座標を自身のゲームオブジェクトに代入する
            }
        }

    }

    void Update()
    {
        _posObj = GameObject.FindGameObjectsWithTag("PosGoal");

        if (_posSwich == true )//座標がずっと同じになってしまうのでロックをかけている
        {
            this.transform.position = _posObj[0].transform.position;
//探してきたゲームオブジェクトの座標を自身のゲームオブジェクトに代入する
            _posSwich = false;
            Debug.Log(_posObj[0]);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _clearCanvas.enabled = true; //プレイヤーがこのオブジェクトに触れたらクリアキャンバスを表示する      
            _spawnGameobject.SetActive(false); //ステージクリア後にオブジェクトを生成しないようにセットアクティブをFalseにする
            _managerGameObject.SetActive(false); //ステージクリア後にsceneをリセットしないようにセットアクティブをFaseにする
            _nextButton.SetActive(true);
            if (_bgmSwich == true )
            {
                _audioSource.Play();
                _bgmSwich = false;
            }
        }
    }
    public void ResetGoalPos()
    {
        _posObj[0] = null;
        Invoke("Swich",0.1f);
//ボタンを押した時にラグがありScene移動前のSceneの値を拾うために少し遅延している        
    }
    void Swich()
    {
        _posSwich = true;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _bgmSwich = true;
    }

}
