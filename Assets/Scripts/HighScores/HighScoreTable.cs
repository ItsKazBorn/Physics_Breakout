using System.Collections.Generic;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    [SerializeField] private List<Score> m_scoreList;

    private LeaderboardManager m_leaderboardManager;
    
    void Start()
    {
        m_leaderboardManager = LeaderboardManager.Instance;
        m_leaderboardManager.GetHighScoreTable();

        for (int i = 0; i < m_leaderboardManager.HighScoreList.Count; i++)
        {
            HighScore score = m_leaderboardManager.HighScoreList[i];
            m_scoreList[i].Setup(score);
        }
    }
}
