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
        _fadePanel.DOFade(1, 0).OnComplete(() => SceneManager.LoadScene(_sceneName));
    }
    public void Move(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void GameScene()
    {
        //����Scene�Ɉړ�����Ƃ����̃��\�b�h���g�����ƂŊy�ɂȂ�
        if (SceneManager.GetActiveScene().name == "GameScene1-1")
        {
            SceneManager.LoadScene("GameScene1-2");
        }
        else if (SceneManager.GetActiveScene().name == "GameScene1-2")
        {
            SceneManager.LoadScene("GameScene1-3");
        }
        else if (SceneManager.GetActiveScene().name == "GameScene1-3")
        {
            SceneManager.LoadScene("GameScene1-4");
        }
        else if (SceneManager.GetActiveScene().name == "GameScene1-4")
        {
            SceneManager.LoadScene("GameScene1-5");
        }
        else if (SceneManager.GetActiveScene().name == "GameScene1-5")
        {
            SceneManager.LoadScene("GameScene1-6");
        }
        else if (SceneManager.GetActiveScene().name == "GameScene1-6")
        {
            SceneManager.LoadScene("GameScene1-7");
        }
        if (SceneManager.GetActiveScene().name == "GameScene1-7")
        {
            SceneManager.LoadScene("GameScene1-8");
        }
        this.gameObject.SetActive(false);
        //�Z�b�g�A�N�e�B�u���I���ɂȂ��Ă���Ǝ��̃X�e�[�W�ɍs���Ă��܂��̂ŃI�t�ɂ���
    }
}
