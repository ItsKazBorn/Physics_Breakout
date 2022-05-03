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

    private int m_lives = 3;
    private int m_currentBlocks = 0;

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
    }

    public void RemoveBlock()
    {
        m_currentBlocks--;
        //Check End Game
        if (m_currentBlocks <= 0)
        {
            EndGame();
        }
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
        
        return lives * 1000 / Mathf.FloorToInt(time);
    }
}
