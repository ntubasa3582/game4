using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSelected : MonoBehaviour
{
    void Start()
    {
        //�ŏ��ɑI������{�^���ɕt����
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}