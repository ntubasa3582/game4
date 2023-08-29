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
    //�R���C�_�[�̃I�t�Z�b�g
    const float _offset = 1.8f;
    //���̃I�u�W�F�N�g�̎q�I�u�W�F�N�g
    GameObject _goChild;
    //�q�I�u�W�F�N�g��CIrcleCollider2D
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
        yield return new WaitForSeconds(1);
        rigidbody2D.drag -= 3;
    }
}
