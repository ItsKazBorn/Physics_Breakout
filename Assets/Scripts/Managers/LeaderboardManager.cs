using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HighScores
{
    public List<HighScore> HighScoresList;
}

[System.Serializable]
public struct HighScore
{
    public int Score;
    public float PlayTime;
    public string Name;
}

public class LeaderboardManager : MonoBehaviour
{
    #region Singleton Stuff

    private static LeaderboardManager m_instance;

    public static LeaderboardManager Instance => m_instance;
    
    void Awake()
    {
        m_instance = this;
    }

    #endregion

    private const string HIGH_SCORE_LIST_KEY = "highScoreTable";
    private const int NUM_OF_SCORES = 10;

    private List<HighScore> m_highScores = new List<HighScore>();

    public List<HighScore> HighScoreList => m_highScores;
    
    private void Start()
    {
        GetHighScoreTable();
    }

    public bool CheckHighScores(HighScore newScore)
    {
        HighScore lastHighScore = m_highScores[m_highScores.Count - 1];
        if (newScore.Score > lastHighScore.Score)
        {
            return true;
        }
        return newScore.Score == lastHighScore.Score && newScore.PlayTime < lastHighScore.PlayTime;
    }

    public void SubmitHighScore(HighScore highScore)
    {
        AddNewEntry(highScore);
    }

    public void AddNewEntry(HighScore highScore)
    {
        m_highScores[m_highScores.Count - 1] = highScore;
        m_highScores.Sort((s1, s2) => s1.PlayTime.CompareTo(s2.PlayTime));
        m_highScores.Reverse();
        m_highScores.Sort((s1, s2) => s1.Score.CompareTo(s2.Score));
        m_highScores.Reverse();
        SaveList();
    }

    private void SaveList()
    {
        HighScores highScores = new HighScores { HighScoresList = m_highScores };
        string json = JsonUtility.ToJson(highScores);
        
        PlayerPrefs.SetString(HIGH_SCORE_LIST_KEY, json);
    }

    public void GetHighScoreTable()
    {
        if (PlayerPrefs.HasKey(HIGH_SCORE_LIST_KEY))
        {
            string jsonString = PlayerPrefs.GetString(HIGH_SCORE_LIST_KEY);
            HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

            m_highScores = highScores.HighScoresList;
        }
        else
        {
            PopulateHighScores();
            // CreateScores();
            SaveList();
        }
    }
    
    private void PopulateHighScores()
    {
        for (int i = 0; i < NUM_OF_SCORES; i++)
        {
            HighScore highScore= new HighScore { Name = String.Empty, Score = 0, PlayTime = 0 };
            m_highScores.Add(highScore);
        }
    }

    private void CreateScores()
    {
        HighScore score1 = new HighScore { Name = "1", Score = 1000000000, PlayTime = 60 };
        HighScore score2 = new HighScore { Name = "2", Score = 100000000, PlayTime = 60 };
        HighScore score3 = new HighScore { Name = "3", Score = 10000000, PlayTime = 60 };
        HighScore score4 = new HighScore { Name = "4", Score = 1000000, PlayTime = 60 };
        HighScore score5 = new HighScore { Name = "5", Score = 100000, PlayTime = 60 };
        HighScore score6 = new HighScore { Name = "6", Score = 10000, PlayTime = 60 };
        HighScore score7 = new HighScore { Name = "7", Score = 1000, PlayTime = 50 };
        HighScore score8 = new HighScore { Name = "8", Score = 1000, PlayTime = 60 };
        HighScore score9 = new HighScore { Name = "9", Score = 10, PlayTime = 50 };
        HighScore score10 = new HighScore { Name = "10", Score = 10, PlayTime = 60 };
        AddNewEntry(score1);
        AddNewEntry(score2);
        AddNewEntry(score3);
        AddNewEntry(score4);
        AddNewEntry(score5);
        AddNewEntry(score6);
        AddNewEntry(score7);
        AddNewEntry(score8);
        AddNewEntry(score9);
        AddNewEntry(score10);
    }
}
