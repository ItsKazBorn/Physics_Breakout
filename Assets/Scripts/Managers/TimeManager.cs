
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager m_instance;
    public static TimeManager Instance => m_instance;

    private void Awake()
    {
        m_instance = this;
    }

    private bool m_isRunning = false;
    private float m_currentTime = 0f;

    public float CurrentTime => m_currentTime;

    // Update is called once per frame
    void Update()
    {
        if (m_isRunning)
        {
            m_currentTime += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        m_currentTime = 0f;
        m_isRunning = true;
    }

    public void StopTimer()
    {
        m_isRunning = false;
    }
    
    public string DisplayTime()
    {
        float minutes = Mathf.FloorToInt(m_currentTime / 60);
        float seconds = Mathf.FloorToInt(m_currentTime % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    public string DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
