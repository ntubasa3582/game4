using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void SceneMove11(string  sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
