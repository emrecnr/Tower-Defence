using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        instance = this;
    }
    private GameObject towerBuild; // build edilecek kule

    public GameObject archerTowerPref;// okçu kule prefab
    public GameObject magicTowerPref; // büyücü kule prefab

    


    public GameObject GetTowerBuild()
    {
        return towerBuild;
    }
    public void SetTowerBuild(GameObject tower)
    {
        towerBuild = tower;
    }
}
