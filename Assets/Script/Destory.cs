using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour
{
    [SerializeField] float _interval;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,_interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
