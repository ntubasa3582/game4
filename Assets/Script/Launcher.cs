using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(BoxCollider2D))]

public class Launcher : MonoBehaviour
{
    [SerializeField] float _impulsePower;
    [SerializeField] string _direction;
    Collider2D _touchingCollider;
    Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GameObject" || collision.gameObject.tag == "Player")
        {
            collision.rigidbody.AddForce(Vector2.up * _impulsePower, ForceMode2D.Impulse);
        }


    }
}
