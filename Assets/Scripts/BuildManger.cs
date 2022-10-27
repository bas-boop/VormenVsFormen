using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManger : MonoBehaviour
{
    
    /// <summary>
    /// This script's main responsibility is to gather the available towers to the player 
    /// and to be able to build them into the level
    /// </summary>

    public static BuildManger instance;

    void Awake()
    {
        if (instance != null) 
        {
            Debug.LogError("Meerdere Buildmangers");
            return;
        }
        instance = this;
    }

    [SerializeField]private GameObject[] TowerPrefabs;
   

    private TowerBlueprint towerToBuild;
    private TileScript selectedTile;

    public TileUI tileUI;

    public bool CanBuild { get { return towerToBuild != null; } }

    public void SelectTile(TileScript tile)
    {
        if(selectedTile == tile)
        {
            DeslectTile();
            return;
        }

        selectedTile = tile;
        towerToBuild = null;

        tileUI.SetTarget(tile);
    }

    public void DeslectTile()
    {
        selectedTile = null;
        tileUI.Hide();
    }

    public void SelectTowerToBuild(TowerBlueprint tower)//een tower wordt gebuild
    {
        towerToBuild = tower;
        DeslectTile();
    }

    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }
}
