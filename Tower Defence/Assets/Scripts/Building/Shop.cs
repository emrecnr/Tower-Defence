using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseArcherTower()
    {
        Debug.Log("Archer Tower Purchased");
        buildManager.SetTowerBuild(buildManager.archerTowerPref);
    }

    public void PurchaseAnotherTower()
    {
        Debug.Log("Magic Tower Purchased");
        buildManager.SetTowerBuild(buildManager.magicTowerPref);
    }
}
