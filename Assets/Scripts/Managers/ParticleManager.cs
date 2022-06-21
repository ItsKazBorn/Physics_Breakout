using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ParticleManager : MonoBehaviour
{
    #region Singleton Stuff

    private static ParticleManager m_instance;

    public static ParticleManager Instance => m_instance;

    private void Awake()
    {
        m_instance = this;
    }

    #endregion
    
    
    [SerializeField] private List<GameObject> m_ballHitObjectParticles;
    
    [SerializeField] private List<GameObject> m_planetTookDamageParticles;

    [SerializeField] private List<GameObject> m_planetDestroyedParticles;

    public void BallHitObject(Vector3 position)
    {
        int random = Random.Range(0, m_ballHitObjectParticles.Count - 1);
        Instantiate(m_ballHitObjectParticles[random], position, Quaternion.identity);
    }

    public void PlanetTookDamage(Vector3 position)
    {
        int random = Random.Range(0, m_planetTookDamageParticles.Count - 1);
        Instantiate(m_planetTookDamageParticles[random], position, Quaternion.identity);
    }

    public void PlanetDestroyed(Vector3 position)
    {
        int random = Random.Range(0, m_planetDestroyedParticles.Count - 1);
        Instantiate(m_planetDestroyedParticles[random], position, Quaternion.identity);
    }
    
    
    
    

}
