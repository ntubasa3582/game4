using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioDDOL : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _obj1;
    //[SerializeField] GameObject _obj2;
    void Start()
    {
        if (FindObjectsOfType<AudioDDOL>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(_obj1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
