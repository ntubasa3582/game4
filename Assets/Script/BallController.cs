using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [Header("X���W")] 
    [SerializeField, Tooltip("X���W")] float _xpos;

    [Header("Y���W")]
    [SerializeField, Tooltip("Y���W")] float _ypos;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //����������I�u�W�F�N�g�������ʒu�ɖ߂�
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
