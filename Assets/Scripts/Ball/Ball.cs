
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;

    private Rigidbody2D _rigidbody2D;

    private int _hitWall = 0;
    
    // Start is called before the first frame update
    void Start()
    {
    //Comentario aqui
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.up * _speed;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
        _rigidbody2D.velocity = Vector2.up * _speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 11) // Is Balls Destroyer
        {
            GameManager.Instance.RemoveLife(this);
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 9) // Is Walls
        {
            _hitWall++;
            if (_hitWall >= 3)
            {
                Vector2 direction = GetHitFactor(transform.position, other.transform.position, other.collider.bounds.size);
                _rigidbody2D.velocity = direction * _speed;
            }
        }
        else
        {
            Vector3 pos = transform.position;
            _hitWall = 0;
            Vector2 direction = GetHitFactor(pos, other.transform.position, other.collider.bounds.size).normalized;
            _rigidbody2D.velocity = direction * _speed;

            if (other.gameObject.layer != 7) // Is not Ball
            {
                ParticleManager.Instance.BallHitObject(pos);
            }
        }
    }

    private Vector2 GetHitFactor(Vector2 ballPos, Vector2 otherPos, Vector3 otherSize)
    {
        float x = (ballPos.x - otherPos.x) / otherSize.x;
        float y = (ballPos.y - otherPos.y) / otherSize.y;

        return new Vector2(x, y).normalized;
    }
}
