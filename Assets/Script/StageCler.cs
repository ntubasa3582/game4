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
    [SerializeField] GameObject _nextButton;
    GameObject[] _posObj;
    AudioSource _audioSource;
    AudioClip _clip;
    bool _posSwich= false;
    bool _bgmSwich= true;
    private void Awake()
    {
        Invoke("Swich", 0.1f);
        SceneManager.sceneLoaded += OnSceneLoaded;
        _audioSource = GetComponent<AudioSource>();
        _clip = GetComponent<AudioClip>();
        _clearCanvas.enabled = false;
        _posObj = GameObject.FindGameObjectsWithTag("PosGoal");//PosGoal�̃^�O���t���Ă���Q�[���I�u�W�F�N�g��T���Ă���
        if (_posObj != null)
        {
            if (SceneManager.GetActiveScene().name != "Title")
            {
                this.transform.position = _posObj[0].transform.position;
                //�T���Ă����Q�[���I�u�W�F�N�g�̍��W�����g�̃Q�[���I�u�W�F�N�g�ɑ������
            }
        }

    }

    void Update()
    {
        _posObj = GameObject.FindGameObjectsWithTag("PosGoal");

        if (_posSwich == true )//���W�������Ɠ����ɂȂ��Ă��܂��̂Ń��b�N�������Ă���
        {
            this.transform.position = _posObj[0].transform.position;
//�T���Ă����Q�[���I�u�W�F�N�g�̍��W�����g�̃Q�[���I�u�W�F�N�g�ɑ������
            _posSwich = false;
            Debug.Log(_posObj[0]);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _clearCanvas.enabled = true; //�v���C���[�����̃I�u�W�F�N�g�ɐG�ꂽ��N���A�L�����o�X��\������      
            _spawnGameobject.SetActive(false); //�X�e�[�W�N���A��ɃI�u�W�F�N�g�𐶐����Ȃ��悤�ɃZ�b�g�A�N�e�B�u��False�ɂ���
            _managerGameObject.SetActive(false); //�X�e�[�W�N���A���scene�����Z�b�g���Ȃ��悤�ɃZ�b�g�A�N�e�B�u��Fase�ɂ���
            _nextButton.SetActive(true);
            if (_bgmSwich == true )
            {
                _audioSource.Play();
                _bgmSwich = false;
            }
        }
    }
    public void ResetGoalPos()
    {
        _posObj[0] = null;
        Invoke("Swich",0.1f);
//�{�^�������������Ƀ��O������Scene�ړ��O��Scene�̒l���E�����߂ɏ����x�����Ă���        
    }
    void Swich()
    {
        _posSwich = true;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _bgmSwich = true;
    }

}
