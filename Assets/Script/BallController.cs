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
    //コライダーのオフセット
    const float _offset = 1.8f;
    //このオブジェクトの子オブジェクト
    GameObject _goChild;
    //子オブジェクトのCIrcleCollider2D
    CircleCollider2D _cC2D;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        _goChild = this.transform.GetChild(0).gameObject;
        _cC2D = _goChild.GetComponent<CircleCollider2D>();
        _cC2D.radius = _offset;
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
        yield return new WaitForSeconds(1);
        rigidbody2D.drag -= 3;
    }
}
