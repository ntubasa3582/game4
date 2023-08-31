using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneMove : MonoBehaviour
{
    [SerializeField] float _interval;
    [SerializeField] string sceneName;
    [SerializeField] Image _fade;
    [SerializeField] int _fadeMode; //0‚Æ1

    public void SceneMove11()
    {
        _fade.gameObject.SetActive(true);
        _fade.DOFade(1, _interval).OnComplete(() => SceneManager.LoadScene(sceneName));
       // StartCoroutine("Scenemove");
    }

}
