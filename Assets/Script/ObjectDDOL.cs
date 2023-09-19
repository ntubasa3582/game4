using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDDOL : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _group;
    [SerializeField] GameObject[] _object;
    [SerializeField] Canvas _canvas;
    [SerializeField] string _sceneName;
    // Update is called once per frame
    void Start()
    {
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
            _object[0].SetActive(false);
            _object[1].SetActive(false);
            _canvas.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "GameScene1-1" || SceneManager.GetActiveScene().name == "GameScene1-2" || SceneManager.GetActiveScene().name == "GameScene1-3" || SceneManager.GetActiveScene().name == "GameScene1-4" || SceneManager.GetActiveScene().name == "GameScene1-5" || SceneManager.GetActiveScene().name == "GameScene1-6" || SceneManager.GetActiveScene().name == "GameScene1-7")
        {
            _object[0].SetActive(true);
            _object[1].SetActive(true);
            _canvas.enabled = false;
        }
    }
}
