using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    [Header("sceneの名前")]
    [SerializeField, Tooltip("リセットしたいSceneの名前を入れる")] string _SceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.R)) //Rキーを押したらSceneをリロードできる
        {
            SceneManager.LoadScene(_SceneName);
        } 
    }
}
