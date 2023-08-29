using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    [SerializeField] float _interval;
    [SerializeField] string sceneName;

    public void SceneMove11()
    {
        StartCoroutine("Scenemove");
    }
    IEnumerator Scenemove()
    {
        yield return new WaitForSeconds(_interval);
        SceneManager.LoadScene(sceneName);
    }

}
