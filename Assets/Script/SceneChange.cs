using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] float _interval;//フェードインまでの時間
    //[SerializeField] string _sceneName;//Sceneの名前
    [SerializeField,Tooltip("フェードインパネル")] Image _fadePanel;//フェードパネル
    [SerializeField] int _fadeMode; //0がフェードインで1がフェードアウト
    public void SceneMove(string _sceneName)
    {
        _fadePanel.gameObject.SetActive(true); //フェードインパネルを非アクティブからアクティブにする
        //１つ目の引数はフェードインパネルのa値を0から255にする
        _fadePanel.DOFade(1, 0).OnComplete(() => SceneManager.LoadScene(_sceneName));
    }
    public void Move(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void GameScene()
    {
        //次のSceneに移動するときこのメソッドを使うことで楽になる
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
        //セットアクティブがオンになっていると次のステージに行けてしまうのでオフにする
    }
}
