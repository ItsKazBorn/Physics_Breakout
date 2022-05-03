using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private static MenuManager m_instance;
    public static MenuManager Instance => m_instance;
    
    private const string GAME_SCENE = "SampleScene";

    private void Awake()
    {
        m_instance = this;
    }

    public void PlayGameButtonPressed()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    public void OptionsButtonPressed()
    {
        Debug.Log("Options Button Pressed");
    }

    public void CreditsButtonPressed()
    {
        Debug.Log("Credits Button Pressed");
    }

    public void ExitGameButtonPressed()
    {
        Application.Quit();
    }
}
