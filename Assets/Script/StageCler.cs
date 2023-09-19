using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageCler : MonoBehaviour
{
    [SerializeField] GameObject _spawnGameobject;
    [SerializeField] GameObject _managerGameObject;
    [SerializeField] Canvas _clearCanvas;

    private void Start()
    {
        _clearCanvas.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _clearCanvas.enabled = true; //�v���C���[�����̃I�u�W�F�N�g�ɐG�ꂽ��N���A�L�����o�X��\������      
            _spawnGameobject.SetActive(false); //�X�e�[�W�N���A��ɃI�u�W�F�N�g�𐶐����Ȃ��悤�ɃZ�b�g�A�N�e�B�u��False�ɂ���
            _managerGameObject.SetActive(false); //�X�e�[�W�N���A���scene�����Z�b�g���Ȃ��悤�ɃZ�b�g�A�N�e�B�u��Fase�ɂ���
        }
    }
}
