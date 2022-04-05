using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadSceneButton : MonoBehaviour
{
    private Button m_button;
    
    // Start is called before the first frame update
    void Start()
    {
        m_button = GetComponent<Button>();
        
        m_button.onClick.AddListener(ReloadScene);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
