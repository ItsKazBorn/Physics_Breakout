using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager Instance => m_instance;

    [Header("Prefabs")] 
    [SerializeField] private GameObject m_ball;
    [SerializeField] private GameObject m_extraBallPowerUp;
    
    [Header("Managers")]
    private TimeManager m_timeManager;
    private LeaderboardManager m_leaderboardManager;

    [Header("UI Stuff")]
    [SerializeField] private GameObject m_gameOverPanel;
    [SerializeField] private GameObject m_buttonsPanel;
    [SerializeField] private TextMeshProUGUI m_timerText;
    [SerializeField] private TextMeshProUGUI m_scoreText;

    [Header("HighScore Stuff")] 
    [SerializeField] private GameObject m_leaderboardPanel;
    [SerializeField] private TMP_InputField m_nameTextField;

    [Header("Game Info")]
    [SerializeField] private int m_lives = 0;
    private int m_currentBlocks = 0;
    private int m_currentScore = -100;

    private List<GameObject> m_powerUps = new List<GameObject>();
    private List<Ball> m_balls = new List<Ball>();

    private bool m_isRunning = true;
    public bool IsRunning => m_isRunning;
    
    void Awake()
    {
        m_instance = this;
    }

    private void Start()
    {
        m_timeManager = TimeManager.Instance;
        m_timeManager.StartTimer();
        m_leaderboardManager = LeaderboardManager.Instance;
        SpawnBall(new Vector3(0, -100, 0));
    }

    private void Update()
    {
        m_timerText.text = m_timeManager.DisplayTime();
        m_scoreText.text = m_currentScore.ToString();
    }

    public void AddBlock()
    {
        m_currentBlocks++;
    }

    public void RemoveBlock()
    {
        m_currentBlocks--;
        AddScore(10);
        if (m_currentBlocks <= 0)
        {
            EndGame();
        }
    }

    public void RemoveLife(Ball ball)
    {
        m_balls.Remove(ball);
        m_lives--;
        if (m_lives <= 0)
        {
            EndGame();
        }
    }

    private void AddScore(int score)
    {
        m_currentScore += score;
    }

    public void SpawnPowerUp(Vector3 position)
    {
        int random = Random.Range(0, 100);
        if (random > 25)
        {
            GameObject extraBall = Instantiate(m_extraBallPowerUp, position, Quaternion.identity);
            m_powerUps.Add(extraBall);
        }
    }
    
    public void SpawnBall(Vector3 position)
    {
        AddScore(100);
        m_lives++;
        Ball ball = Instantiate(m_ball, position, Quaternion.identity).GetComponent<Ball>();
        m_balls.Add(ball);
    }

    private void EndGame()
    {
        m_isRunning = false;
        foreach (GameObject powerUp in m_powerUps)
        {
            Destroy(powerUp);
        }
        
        foreach (Ball ball in m_balls)
        {
            ball.SetSpeed(0f);
        }
        
        m_timeManager.StopTimer();
        m_gameOverPanel.gameObject.SetActive(true);
        m_scoreText.text = m_currentScore.ToString();
        CheckHighScore();
    }

    private void CheckHighScore()
    {
        HighScore score = new HighScore
        {
            Score = m_currentScore, 
            PlayTime = m_timeManager.CurrentTime
        };
        
        if (m_leaderboardManager.CheckHighScores(score))
        {
            m_buttonsPanel.SetActive(false);
            m_leaderboardPanel.SetActive(true);
        }
        else
        {
            m_buttonsPanel.SetActive(true);
            m_leaderboardPanel.SetActive(false);
        }
    }

    public void SubmitHighScore()
    {
        string name = m_nameTextField.text;

        HighScore score = new HighScore 
        { 
            Name = name, 
            Score = m_currentScore, 
            PlayTime = m_timeManager.CurrentTime 
        };
        
        m_leaderboardManager.AddNewEntry(score);
        
        m_buttonsPanel.SetActive(true);
        m_leaderboardPanel.SetActive(false);
    }
    
}
