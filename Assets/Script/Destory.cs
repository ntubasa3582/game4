using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    [SerializeField] float _interval;
    PauseManager2D _pauseManager = default;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,_interval);
        _pauseManager = GameObject.FindObjectOfType<PauseManager2D>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
