using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(BoxCollider2D))]

public class Launcher : MonoBehaviour
{
    [SerializeField] float _impulsePower;
    Collider2D _touchingCollider;
    Rigidbody2D _rigidbody;
    int _direction = 3; //1ÇÕâE 2ÇÕç∂ 3ÇÕè„ 4ÇÕâ∫
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _direction = 1;
            Debug.Log("âE");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _direction = 2;
            Debug.Log("ç∂");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _direction = 3;
            Debug.Log("è„");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _direction = 4;
            Debug.Log("â∫");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GameObject" || collision.gameObject.tag == "Player")
        {
            if (_direction == 1)
            {
                collision.rigidbody.AddForce(Vector2.right * _impulsePower, ForceMode2D.Impulse);//êGÇÍÇΩÇÁâEÇ…çsÇ≠
            }
            else if (_direction == 2)
            {
                collision.rigidbody.AddForce(Vector2.left * _impulsePower, ForceMode2D.Impulse);//êGÇÍÇΩÇÁç∂Ç…çsÇ≠
            }
            else if (_direction == 3)
            {
                collision.rigidbody.AddForce(Vector2.up * _impulsePower, ForceMode2D.Impulse);//êGÇÍÇΩÇÁè„Ç…çsÇ≠
            }
            else
            {
                collision.rigidbody.AddForce(Vector2.down * _impulsePower, ForceMode2D.Impulse);//êGÇÍÇΩÇÁâ∫Ç…çsÇ≠
            }
        }


    }
}
