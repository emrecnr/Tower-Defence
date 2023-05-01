using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelect;
    public void Play()
    {
        SceneManager.LoadScene(1);
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
