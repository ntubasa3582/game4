using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WindowCon : MonoBehaviour
{
    [SerializeField] Canvas _windowCanvas;
    bool _swich = true;
    // Start is called before the first frame update
    void Start()
    {
        _windowCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            
            if (_swich)
            {
                _windowCanvas.enabled = true;
                _swich = false;
            }
            else
            {
                _windowCanvas.enabled = false;
                _swich = true;
            }

            Debug.Log(_swich);
            //Debug.Log("a");
            //_windowCanvas.enabled = true;
            //_swich = true;
            if (_swich)
            {
                //_windowCanvas.enabled = false;
                //_swich = false;
            }
        }
    }
}
