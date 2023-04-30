using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildPoint : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    public Color noMoneyColor;
    [HideInInspector]
    public GameObject tower;
    [HideInInspector]
    public TowerBluePrint towerBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;
    public Vector3 offset;

    private SpriteRenderer render;

    BuildManager buildManager;
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        startColor = render.material.color;
        buildManager = BuildManager.instance;
    }

   public Vector3 GetBuildOffset()
    {
        return transform.position+offset;
    }
    void OnMouseDown()
    {
        
        if (tower != null)
        {
            buildManager.SelectPoint(this);
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        BuildTower(buildManager.GetTowerToBuild());
        

    }
    private void BuildTower(TowerBluePrint bluePrint)
    {
        if (MoneySystem.money < bluePrint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;

        }
        MoneySystem.money -= bluePrint.cost;
        GameObject towerObj = (GameObject)Instantiate(bluePrint.prefab,transform.position, Quaternion.identity);
        towerBluePrint = bluePrint;
        tower = towerObj;

        Debug.Log("Tower build! ");
    }

    public void UpgradeTower()
    {
        if (MoneySystem.money < towerBluePrint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;

        }
        MoneySystem.money -= towerBluePrint.upgradeCost;
        // Destroy old tower
        Destroy(tower);
        // Build a new Tower
        GameObject towerObj = (GameObject)Instantiate(towerBluePrint.upgradedPrefab, transform.position, Quaternion.identity);
        tower = towerObj;
        isUpgraded = true;

        Debug.Log("Tower upgraded! ");
    }
    public void SellTower()
    {
        MoneySystem.money += towerBluePrint.GetSellCost();
        Debug.Log("Selling is done!");

        Destroy(tower);
        towerBluePrint = null;
    }
    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            render.color = hoverColor;

        }
        else
        {
            render.color = noMoneyColor;
        }
        
    }
    void OnMouseExit() 
    {
        render.color = startColor;
    }
}
