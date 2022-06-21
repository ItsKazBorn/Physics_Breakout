
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] private float m_speed = 50f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * (m_speed * Time.deltaTime));
    }
}
