using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLineControllor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GameObject")
        {
            Destroy(collision.gameObject); //生成されるオブジェクトを消している
        }
    }
}
