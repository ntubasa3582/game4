using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    [Header("scene�̖��O")]
    [SerializeField, Tooltip("���Z�b�g������Scene�̖��O������")] string _SceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.R)) //R�L�[����������Scene�������[�h�ł���
        {
            SceneManager.LoadScene(_SceneName);
        } 
    }
}
