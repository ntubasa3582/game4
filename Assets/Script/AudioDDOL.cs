using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioDDOL : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _obj1;
    [SerializeField] GameObject _spawn;
    //[SerializeField] GameObject _obj2;
    void Start()
    {
        if (FindObjectsOfType<AudioDDOL>().Length > 1)//同じゲームオブジェクトがSceneに2個以上ある場合削除する
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(_obj1);//ボタンが押されたときに値を次のsceneに引き継ぐ
        }
    }
}
