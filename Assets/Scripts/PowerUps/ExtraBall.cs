
using UnityEngine;

public class ExtraBall : PowerUp
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8) // is paddle
        {
            GameManager.Instance.SpawnBall(transform.position);
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 11) // Is Ball Destroyer
        {
            Destroy(gameObject);
        }
    }
}
