using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDDOL : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _group;
    [SerializeField] GameObject[] _object;
    [SerializeField] Canvas _canvas;
    [SerializeField] string _sceneName;
    bool _swich = true;
    // Update is called once per frame
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            _object[2].gameObject.SetActive(false);
            _object[7].gameObject.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "StageSelect")
        {
            for (int i = 0; i < _object.Length; i++)
            {
                _object[i].gameObject.SetActive(false);
            }
        }
        if (_swich == true)
        {
            if (SceneManager.GetActiveScene().name == "GameScene1-1" || SceneManager.GetActiveScene().name == "GameScene1-2" || SceneManager.GetActiveScene().name == "GameScene1-3" || SceneManager.GetActiveScene().name == "GameScene1-4" || SceneManager.GetActiveScene().name == "GameScene1-5" || SceneManager.GetActiveScene().name == "GameScene1-6" || SceneManager.GetActiveScene().name == "GameScene1-7")
            {
                for (int i = 0; i < _object.Length; i++)
                {
                    _object[i].gameObject.SetActive(true);
                }
                _swich = false;
            }
        }
    }

    public void DdolObj()
    {

        DontDestroyOnLoad(_group);
        if (SceneManager.GetActiveScene().name == "Title")
        {
            _object[0].SetActive(true);
            _object[1].SetActive(true);
            _canvas.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "StageSelect")
        {
            _object[0].SetActive(false);//オブジェクトをスポーンさせるゲームオブジェクトを使えなくする
            _object[1].SetActive(false);//リスタートしたりサウンドボリュームをいじれなくする
            _canvas.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "GameScene1-1" || SceneManager.GetActiveScene().name == "GameScene1-2" || SceneManager.GetActiveScene().name == "GameScene1-3" || SceneManager.GetActiveScene().name == "GameScene1-4" || SceneManager.GetActiveScene().name == "GameScene1-5" || SceneManager.GetActiveScene().name == "GameScene1-6" || SceneManager.GetActiveScene().name == "GameScene1-7")
        {
            _object[0].SetActive(true);
            _object[1].SetActive(true);
            _canvas.enabled = false;
        }
    }

    public void SwichChange()
    {
        if (_swich == false)
        {
            _swich = true;
        }
        if (_swich == true)
        {
            _swich = false;
        }
    }
}
