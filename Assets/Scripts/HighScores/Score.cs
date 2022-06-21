using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_nameText;
    [SerializeField] private TextMeshProUGUI m_timeText;
    [SerializeField] private TextMeshProUGUI m_scoreText;

    public void Setup(HighScore highScore)
    {
        m_nameText.text = highScore.Name;
        m_scoreText.text = highScore.Score.ToString();
        m_timeText.text = DisplayTime(highScore.PlayTime);
    }
    
    private string DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
