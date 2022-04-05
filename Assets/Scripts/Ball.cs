using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;

    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
    //Comentario aqui
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.up * _speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 direction = GetHitFactor(transform.position, other.transform.position, other.collider.bounds.size);
        _rigidbody2D.velocity = direction * _speed;
    }

    private Vector2 GetHitFactor(Vector2 ballPos, Vector2 otherPos, Vector3 otherSize)
    {
        float x = (ballPos.x - otherPos.x) / otherSize.x;
        float y = (ballPos.y - otherPos.x) / otherSize.y;

        return new Vector2(x, y).normalized;
    }
}
