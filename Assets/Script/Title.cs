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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _fadePanel.DOFade(1, _interval).OnComplete(() => SceneManager.LoadScene(_sceneName));
        }
    }
}
