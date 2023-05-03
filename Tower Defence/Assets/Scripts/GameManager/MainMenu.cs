using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string levelToLoad = "LevelSelect";
    public SceneFader sceneFader;
    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }
    public void Quit()
    {
        Debug.Log("Quit");
    }
    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/devplatanus"); // Twitter hesap yönlendirme.
    }
    
}
