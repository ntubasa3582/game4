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
        if (FindObjectsOfType<AudioDDOL>().Length > 1)//�����Q�[���I�u�W�F�N�g��Scene��2�ȏ゠��ꍇ�폜����
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(_obj1);//�{�^���������ꂽ�Ƃ��ɒl������scene�Ɉ����p��
        }
    }
}
