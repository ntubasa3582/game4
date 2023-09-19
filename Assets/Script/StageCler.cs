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

    private void Start()
    {
        _clearCanvas.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _clearCanvas.enabled = true; //プレイヤーがこのオブジェクトに触れたらクリアキャンバスを表示する      
            _spawnGameobject.SetActive(false); //ステージクリア後にオブジェクトを生成しないようにセットアクティブをFalseにする
            _managerGameObject.SetActive(false); //ステージクリア後にsceneをリセットしないようにセットアクティブをFaseにする
        }
    }
}
