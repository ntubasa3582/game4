using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [Header("X座標")] 
    [SerializeField, Tooltip("X座標")] float _xpos;

    [Header("Y座標")]
    [SerializeField, Tooltip("Y座標")] float _ypos;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //落下したらオブジェクトを初期位置に戻す
        if (collision.gameObject.tag == "DeadLine")
        {
            transform.position = new Vector2(_xpos, _ypos); 
            rigidbody2D.drag += 3;
            StartCoroutine("DragChange");

        }
    }
    IEnumerator DragChange()
    {
        yield return new WaitForSeconds(3);
        rigidbody2D.drag -= 3;
    }
}
