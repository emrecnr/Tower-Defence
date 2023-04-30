using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuildPointUI : MonoBehaviour
{
    private BuildPoint target;

    public GameObject buildUI;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellCost;
    public Button upgradeButton;

    public void SetTarget(BuildPoint selectTarget)
    {
        target = selectTarget;

        transform.position = target.GetBuildOffset();
        if(!target.isUpgraded) 
        {
            upgradeCost.text = "$" + target.towerBluePrint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }
        sellCost.text = "$" + target.towerBluePrint.GetSellCost();
        buildUI.SetActive(true);
    }
    public void Hide()
    {
        buildUI.SetActive(false);
    }
    public void UpgradeTower()
    {
        target.UpgradeTower();
        BuildManager.instance.NoSelectNode();
    }
    
    public void SellTower()
    {
        target.SellTower();
        BuildManager.instance.NoSelectNode();
    }
}
