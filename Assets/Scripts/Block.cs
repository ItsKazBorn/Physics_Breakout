using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int _maxLife = 3;

    private int _currentLife;

    private void Start()
    {
        _currentLife = _maxLife;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            _currentLife--;

            if (_currentLife <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
