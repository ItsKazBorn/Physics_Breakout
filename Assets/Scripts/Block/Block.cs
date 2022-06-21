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
        GameManager.Instance.AddBlock();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            StartCoroutine(TakeDamage());
        }
    }

    private IEnumerator TakeDamage()
    {
        yield return new WaitForSeconds(0.05f);
        _currentLife--;
        Vector3 position = transform.position;
        if (_currentLife <= 0)
        {
            ParticleManager.Instance.PlanetDestroyed(position);
            GameManager.Instance.SpawnPowerUp(position);
            GameManager.Instance.RemoveBlock();
            Destroy(gameObject);
        }
        else
        {
            ParticleManager.Instance.PlanetTookDamage(position);
        }
    }
}
