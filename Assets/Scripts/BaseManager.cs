using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    [System.Serializable]
    public class BuildingPoint
    {
        public Vector3 location;
        public int level;
        public BuildType buildType;
        public GameObject structure;
    }
    public static BaseManager bm;

    [SerializeField] private List<BuildingPoint> _buildingPoints = new List<BuildingPoint>();
    [SerializeField] private StucturesData registry;
    [SerializeField] private EnemiesContained enemiesInBase;

    private void Awake()
    {
        if (bm != null && bm != this)
        {
            Destroy(this.gameObject);
            return;
        }
        bm = this;
        DontDestroyOnLoad(gameObject);
    }
    public void levelUpBuilding(Transform buildPosition)
    {
        BuildingPoint building = _buildingPoints.FirstOrDefault(a => a.location == buildPosition.position);
        if (building == null) { Debug.LogWarning("No building found at position"); return; }
        if (building.buildType == BuildType.Empty)
        {
            building.level = 0;
            PlaceBuilding(BuildType.Harvester, building);
        }
        else
        {
            building.level++;
            PlaceBuilding(building.buildType, building);
        }
    }
    private void BuildBase()
    {
        foreach (var point in _buildingPoints)
        {
            Debug.Log("No build found, creating empty lot");
            if(point.buildType == BuildType.Empty)
                point.level = 0;
            PlaceBuilding(point.buildType, point);
            continue;
        }
    }
    public void PlaceBuilding(BuildType type, BuildingPoint buildLocation)
    {
        if (buildLocation.structure != null)
            Destroy(buildLocation.structure);

        var prefab = registry.GetBuilding(type, buildLocation.level);
        if (prefab == null) return;
        buildLocation.structure = Instantiate(prefab, buildLocation.location, Quaternion.identity);
        buildLocation.buildType = type;
        if (type == BuildType.Harvester) //If more build types are added that do more stuff, change to a switch
        {
            InstantiateEnemy(buildLocation);
        }
    }
    public void InstantiateEnemy(BuildingPoint build)
    {
        if (enemiesInBase.CheckBuilding(build.location))
        {
            Debug.Log(build.structure);
            var harvester = build.structure.GetComponent<Harvester>();
            harvester.InstanciateEnemies(enemiesInBase.GetEnemyByBuild(build.location));
        }
    }
    public void LoadBase()
    {
        StartCoroutine(InitBase());
    }
    private IEnumerator InitBase()
    {
        if (GameManager.gm.capturedEnemy != null)
            SaveEnemy();
        yield return null; // wait one frame for Awake/Start to run
        BuildBase();
    }
    private void SaveEnemy()
    {
        Debug.Log("enemigo en base");

        BuildingPoint harvester = _buildingPoints
            .Where(a => a.buildType == BuildType.Harvester)
            .FirstOrDefault(a => !enemiesInBase.CheckBuilding(a.location));

        if (harvester == null)
        {
            Debug.LogWarning("No available Harvester found to store enemy.");
            return;
        }

        enemiesInBase.StoreEnemy(harvester.location, GameManager.gm.capturedEnemy.prefab);
    }
    public void HarvestEnemy(Vector3 harvesterPosition)
    {
        enemiesInBase.storedEnemies.Remove(enemiesInBase.storedEnemies.FirstOrDefault(n => 
            n.harvesterCoords.x == harvesterPosition.x && n.harvesterCoords.y == harvesterPosition.y && n.harvesterCoords.z == harvesterPosition.z)
        );
        GameManager.gm.Ombrium += 6;
    }
}