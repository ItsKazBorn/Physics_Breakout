using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager Instance => m_instance;

    [Header("Managers")]
    private TimeManager m_timeManager;

    [Header("UI Stuff")]
    [SerializeField] private TextMeshProUGUI m_timerText;
    [SerializeField] private GameObject m_gameOverPanel;
    [SerializeField] private TextMeshProUGUI m_scoreText;

    [Header("Game Info")]
    [SerializeField] private int m_lives = 1;
    private int m_currentBlocks = 0;
    private int m_allBlocks = 0;

    void Awake()
    {
        m_instance = this;
    }

    private void Start()
    {
        m_timeManager = TimeManager.Instance;
        m_timeManager.StartTimer();
    }

    private void Update()
    {
        m_timerText.text = m_timeManager.DisplayTime();
    }

    public void AddBlock()
    {
        m_currentBlocks++;
        m_allBlocks++;
    }

    public void RemoveBlock()
    {
        m_currentBlocks--;
        if (m_currentBlocks <= 0)
        {
            EndGame();
        }
    }

    public void RemoveLife()
    {
        m_lives--;
        if (m_lives <= 0)
        {
            EndGame();
        }
        else
        {
            //Spawn Ball
        }
    }

    public void SpawnBall()
    {
        
    }

    private void EndGame()
    {
        m_timeManager.StopTimer();
        m_gameOverPanel.gameObject.SetActive(true);
        m_scoreText.text = CalculateScore(m_timeManager.CurrentTime, m_lives).ToString();
    }

    private int CalculateScore(float time, int lives)
    {
        Debug.LogError($"{lives} / {Mathf.FloorToInt(time)}");
        int destroyedBlocks = (m_allBlocks - m_currentBlocks) * 100;
        int livesScore = lives * 1000;
        return (destroyedBlocks + livesScore) / Mathf.FloorToInt(time);
    }
}
