using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Awake()
    {
        if (bm != null && bm != this)
        {
            Destroy(this.gameObject);
            return;
        }
        bm = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void levelUpBuilding(Transform buildPosition)
    {
        BuildingPoint building = _buildingPoints.FirstOrDefault(a => a.location == buildPosition.position);
        if (building == null) { Debug.LogWarning("No building found at position"); return; }
        if (building.buildType == BuildType.Empty)
        {
            building.level = 1;
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
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) //Change to game manager
    {
        if(scene == SceneManager.GetSceneByName("Base"))
        {
            BuildBase();
            if(GameManager.gm.capturedEnemy != null)
                SaveEnemy();
        }
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void SaveEnemy()
    {
        Debug.Log("enemigo en base");
        List<BuildingPoint> harvesters = new List<BuildingPoint>();
        harvesters.AddRange(_buildingPoints.Where(a => a.buildType == BuildType.Harvester).ToList());
        BuildingPoint harvester = harvesters.FirstOrDefault(a => a.structure.GetComponent<Harvester>().containedEnemy != null);
        harvester.structure.GetComponent<Harvester>().StoreEnemy();
    }
}