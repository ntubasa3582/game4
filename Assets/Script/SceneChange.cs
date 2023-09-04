using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] float _interval;//フェードインまでの時間
    //[SerializeField] string _sceneName;//Sceneの名前
    [SerializeField,Tooltip("フェードインパネル")] Image _fadePanel;//フェードパネル
    [SerializeField] int _fadeMode; //0がフェードアウトで1がフェードイン
    public void SceneMove(string _sceneName)
    {
        _fadePanel.gameObject.SetActive(true); //フェードインパネルを非アクティブからアクティブにする
        //１つ目の引数はフェードインパネルのa値を0から255にする
        _fadePanel.DOFade(1, _interval).OnComplete(() => SceneManager.LoadScene(_sceneName));
    }

}
