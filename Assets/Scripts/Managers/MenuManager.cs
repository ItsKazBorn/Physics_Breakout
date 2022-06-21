using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private static MenuManager m_instance;
    public static MenuManager Instance => m_instance;
    
    private const string GAME_SCENE = "Game";
    private const string LEADERBOARDS_SCENE = "Leaderboards";
    private const string MAIN_MENU_SCENE = "MainMenu";

    private void Awake()
    {
        m_instance = this;
    }

    public void PlayGameButtonPressed()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    public void MainMenuButtonPressed()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE);
    }
    
    public void LeaderboardsButtonPressed()
    {
        SceneManager.LoadScene(LEADERBOARDS_SCENE);
    }

    public void ExitGameButtonPressed()
    {
        Application.Quit();
    }
}
