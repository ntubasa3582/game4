using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSelected : MonoBehaviour
{
    void Start()
    {
        //最初に選択するボタンに付ける
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}