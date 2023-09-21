using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager2D : MonoBehaviour
{
    bool _pauseFlg = false;
    public delegate void Pause(bool isPause);
    public event Action<bool> OnPauseResume; //esc�L�[��Pause��ʂ��Ăяo��
    public event Action OnResetScene; //Space��Scene�̏�����������
    void Update()
    {
        //ESC�L�[����������Scene��̃I�u�W�F�N�g���~�܂�A�I�[�f�B�I�E�B���h�E���J��
        if (Input.GetButtonDown("Cancel"))
        {
            _pauseFlg = !_pauseFlg;
            OnPauseResume(_pauseFlg);
        }
        //SPACE�L�[�������ꂽ�琶�����ꂽ�I�u�W�F�N�g���폜���ă{�[���������ʒu�ɖ߂�
        if (Input.GetButtonDown("Jump"))
        {
            OnResetScene();
        }
    }


}
