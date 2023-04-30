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
    private TowerBluePrint towerBuild; // build edilecek kule
    private BuildPoint selectedPoint;
    

    public bool CanBuild { get { return towerBuild != null; } }
    public bool HasMoney { get { return MoneySystem.money>= towerBuild.cost; } }

    public GameObject archerTowerPref;// okçu kule prefab
    public GameObject magicTowerPref; // büyücü kule prefab
    public GameObject stoneTowerPref; // taþçý kule prefab

    public BuildPointUI buildPointUI;
    
    
    public void SelectPoint(BuildPoint buildPoint)
    {
        if (selectedPoint == buildPoint)
        {
            NoSelectNode();
            return;
        }
        selectedPoint = buildPoint;
        towerBuild = null;
        buildPointUI.SetTarget(buildPoint);
    }
    public void NoSelectNode()
    {
        selectedPoint = null;
        buildPointUI.Hide();
    }
   public void SelectTowerBuild(TowerBluePrint tower)
    {
        towerBuild = tower;
        NoSelectNode();
    }
    public TowerBluePrint GetTowerToBuild() 
    { 
        return towerBuild;
    
    }
}  
