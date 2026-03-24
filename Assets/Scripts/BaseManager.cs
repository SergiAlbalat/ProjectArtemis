using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    [System.Serializable]
    public class BuildingPoint
    {
        public Transform location;
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
        foreach (var point in _buildingPoints)
        {
            if (point.structure == null)
            {
                Debug.Log("No build found, creating empty lot");
                point.level = 0;
                PlaceBuilding(BuildType.Empty, point);
                continue;
            }
        }
    }
    public void levelUpBuilding(Transform buildPosition)
    {
        BuildingPoint building = _buildingPoints.FirstOrDefault(a => a.location == buildPosition);
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
    public void PlaceBuilding(BuildType type, BuildingPoint buildLocation)
    {
        if (buildLocation.structure != null)
            Destroy(buildLocation.structure);

        var prefab = registry.GetBuilding(type, buildLocation.level);
        if (prefab == null) return;
        buildLocation.structure = Instantiate(prefab, buildLocation.location.position, Quaternion.identity);
        buildLocation.buildType = type;
    }
}