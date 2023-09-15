using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] float _interval;//�t�F�[�h�C���܂ł̎���
    //[SerializeField] string _sceneName;//Scene�̖��O
    [SerializeField,Tooltip("�t�F�[�h�C���p�l��")] Image _fadePanel;//�t�F�[�h�p�l��
    [SerializeField] int _fadeMode; //0���t�F�[�h�C����1���t�F�[�h�A�E�g
    public void SceneMove(string _sceneName)
    {
        _fadePanel.gameObject.SetActive(true); //�t�F�[�h�C���p�l�����A�N�e�B�u����A�N�e�B�u�ɂ���
        //�P�ڂ̈����̓t�F�[�h�C���p�l����a�l��0����255�ɂ���
        _fadePanel.DOFade(1, _interval).OnComplete(() => SceneManager.LoadScene(_sceneName));
    }

}
