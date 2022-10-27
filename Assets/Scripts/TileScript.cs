using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    public Color hoverColer;

    [HideInInspector]
    public GameObject tower;
    [HideInInspector]
    public TowerBlueprint towerBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColer;

    BuildManger buildManger;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColer = rend.material.color;

        buildManger = BuildManger.instance;
    }

    void BuildTower(TowerBlueprint blueprint)
    {
        if (PlayerStats.euro < blueprint.cost)
        {
            Debug.Log("ha ha, u poor");
            return;
        }

        PlayerStats.euro -= blueprint.cost;

        towerBlueprint = blueprint;

        GameObject _tower = (GameObject)Instantiate(blueprint.prefab, transform.position, transform.rotation);
        _tower.transform.SetParent(transform);
        tower = _tower;
    }

    public void UpgradeTower()
    {
        if (PlayerStats.euro < towerBlueprint.upgradeCost)
        {
            Debug.Log("ha ha, u poor");
            return;
        }

        PlayerStats.euro -= towerBlueprint.upgradeCost;

        //de oude tower verwijderen
        Destroy(tower);

        //nieuwe tower neer zetten
        GameObject _tower = (GameObject)Instantiate(towerBlueprint.upgradePrefab, transform.position, transform.rotation);
        _tower.transform.SetParent(transform);
        tower = _tower;

        isUpgraded = true;
    }

    public void SellTower()
    {
        if (PlayerStats.euro < towerBlueprint.sellCost)
        {
            Debug.Log("ha ha, u poor?");
            return;
        }

        Destroy(tower);
    }

    void OnMouseEnter()
    {
        /*if (EventSystem.current.IsPointerOverGameObject())
            return;*/
        if (!buildManger.CanBuild)
            return;
        rend.material.color = hoverColer;
    }

    void OnMouseExit()
    {
        rend.material.color = startColer;
    }
    
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (tower != null)
        {
            buildManger.SelectTile(this);
            return;
        }

        if (!buildManger.CanBuild)
            return;

        BuildTower(buildManger.GetTowerToBuild());
    }
}
