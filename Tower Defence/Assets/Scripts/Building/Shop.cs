using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBluePrint archerTower;
    public TowerBluePrint magicTower;
    public TowerBluePrint stoneTower;

    
    public void SelectArcherTower()
    {
        Debug.Log("Archer Tower Purchased");
        BuildManager.instance.SelectTowerBuild(archerTower);
    }

    public void SelectMagicTower()
    {
        Debug.Log("Magic Tower Purchased");
        BuildManager.instance.SelectTowerBuild(magicTower);
    }

    public void SelectStoneTower() 
    {
        Debug.Log("Stone Tower Purchased");
        BuildManager.instance.SelectTowerBuild(stoneTower);
    }
}
