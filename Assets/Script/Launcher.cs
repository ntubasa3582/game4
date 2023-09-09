using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(BoxCollider2D))]

public class Launcher : MonoBehaviour
{
    [SerializeField] float _impulsePower1;
    [SerializeField] float _ImpulsePower2;

    [SerializeField,Header("1ÇÕâE 2ÇÕç∂")] int _impulseMode;
    Collider2D _touchingCollider;
    Rigidbody2D _rigidbody;
    int _direction;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _direction = Random.Range(1, 4);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GameObject" || collision.gameObject.tag == "Player")
        {
            collision.rigidbody.AddForce(Vector2.up * _impulsePower1, ForceMode2D.Impulse);//êGÇÍÇΩÇÁè„Ç…çsÇ≠
            if (_impulseMode == 1)
            {
                collision.rigidbody.AddForce(Vector2.right * _ImpulsePower2, ForceMode2D.Impulse);
            }
            else if (_impulseMode == 2)
            {
                collision.rigidbody.AddForce(Vector2.left * _ImpulsePower2, ForceMode2D.Impulse);
            }
        }
    }
}
