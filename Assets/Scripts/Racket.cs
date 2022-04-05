using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class Racket : MonoBehaviour
{
    [FormerlySerializedAs("speed")] [SerializeField] private float _speed = 150;

    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        _rigidbody2D.velocity = Vector2.right * horizontalAxis * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
