using UnityEngine;
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
        if (GameManager.Instance.IsRunning)
        {
            float horizontalAxis = Input.GetAxisRaw("Horizontal");

            _rigidbody2D.velocity = Vector2.right * (horizontalAxis * _speed);
        }
    }
}
