using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public string nextLevel = "Level2";
    public int levelToUnlock = 2;

    public GameObject complateLevelUI;
    public void WinLevel()
    {
        complateLevelUI.SetActive(true);
    }
}
