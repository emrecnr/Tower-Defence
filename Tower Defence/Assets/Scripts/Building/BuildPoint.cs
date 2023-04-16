using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPoint : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    private GameObject tower;

    private SpriteRenderer render;

    BuildManager buildManager;
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        startColor = render.material.color;
        buildManager = BuildManager.instance;
    }

  
    void OnMouseDown()
    {
        if (buildManager.GetTowerBuild() == null)
        {
            return;
        }
        if (tower != null)
        {
            Debug.Log("Cant build there!");
            return;
        }
        GameObject towerBuild = buildManager.GetTowerBuild();
        tower = (GameObject)Instantiate(towerBuild,transform.position,Quaternion.identity);
        Destroy(gameObject);

    }

    void OnMouseEnter()
    {
        if (buildManager.GetTowerBuild() == null)
        {
            return;
        }
        render.color = hoverColor;
    }
    void OnMouseExit() 
    {
        render.color = startColor;
    }
}
