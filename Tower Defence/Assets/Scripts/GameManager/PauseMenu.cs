using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        

    }
    public void PauseGame() // Oyunu durdur
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        if (pauseMenuUI.activeSelf) 
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry() // Tekrar y�kle
    {
        PauseGame();

        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        
    }

    public void Menu() // Menu Button
    {
        Debug.Log("Go to Menu");
        PauseGame();
        sceneFader.FadeTo("MainMenu");
    }

}
