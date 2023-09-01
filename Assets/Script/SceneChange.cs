using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] float _interval;//�t�F�[�h�C���܂ł̎���
    //[SerializeField] string _sceneName;//Scene�̖��O
    [SerializeField] Image _fadePanel;//�p�l��
    [SerializeField] int _fadeMode; //0���t�F�[�h�A�E�g��1���t�F�[�h�C��
    public void SceneMove(string _sceneName)
    {
        _fadePanel.gameObject.SetActive(true);
        _fadePanel.DOFade(1, _interval).OnComplete(() => SceneManager.LoadScene(_sceneName));
    }

}
