using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    #region Inspector

    

    #endregion
    
    
    #region Unity Event Functions

    private void Start()
    {
        Time.timeScale = 1f;
    }

    #endregion

    #region Button Events

    public void StartButton()
    {
        SceneManager.LoadScene("Sandbox");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    #endregion
}
