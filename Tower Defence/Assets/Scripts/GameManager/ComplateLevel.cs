using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplateLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public string nextLevel = "Level2";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public void NextLevel()
    {
        PlayerPrefs.SetInt("levelReached",levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
