using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Title : MonoBehaviour
{
    [SerializeField] Image _fadePanel;
    [SerializeField] string _sceneName;
    [SerializeField] float _interval;
    [SerializeField] GameObject[] _text;
    [SerializeField] GameObject _ddolgo;
    int _objectCount = 0; //0が黄色 1緑色 2赤色
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _objectCount++;
            if (_objectCount > 2)
            {
                _objectCount = 0;
            }
            Debug.Log(_objectCount);
        }
        //オブジェクトの説明をしているテキストを切り替えている
        if (_objectCount == 0)
        {
            _text[0].SetActive(true);
            _text[1].SetActive(false);
            _text[2].SetActive(false);
        }
        else if (_objectCount == 1)
        {
            _text[0].SetActive(false);
            _text[1].SetActive(true);
            _text[2].SetActive(false);
        }
        else if ( _objectCount == 2)
        {
            _text[0].SetActive(false);
            _text[1].SetActive(false);
            _text[2].SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _fadePanel.DOFade(1, _interval).OnComplete(() => SceneManager.LoadScene(_sceneName));
            DontDestroyOnLoad(_ddolgo);
        }
    }
}
