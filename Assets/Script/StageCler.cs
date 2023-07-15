using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageCler : MonoBehaviour
{
    [SerializeField] float _interval = 1;
    [SerializeField] Text _clearText;

    private void Start()
    {
        _clearText.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _clearText.enabled = true;
            StartCoroutine("SceneChange");
        }
    }
    public void SceneMove()
    {
        SceneManager.LoadScene("StageSelect");
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(_interval);
        SceneMove();
        
    }
}
