using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint iceTower;
    public TowerBlueprint fireTower;
    public TowerBlueprint posionTower;
    public TowerBlueprint windTower;

    BuildManger buildManger;

    private void Start()
    {
        buildManger = BuildManger.instance;
    }

    public void SelectIceTower()
    {
        Debug.Log("ice ice baby");
        buildManger.SelectTowerToBuild(iceTower);
    }
    public void SelectFireTower()
    {
        Debug.Log("불타오르네");
        buildManger.SelectTowerToBuild(fireTower);
    }
    public void SelectPosionTower()
    {
        Debug.Log("vergif");
        buildManger.SelectTowerToBuild(posionTower);
    }
    public void SelectWindTower()
    {
        Debug.Log("風");
        buildManger.SelectTowerToBuild(windTower);
    }
}
