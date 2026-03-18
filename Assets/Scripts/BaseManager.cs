using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    [System.Serializable]
    public class BuildingPoint
    {
        public Transform location;
        public Stuctures structure;
    }

    [SerializeField] private List<BuildingPoint> _buildingPoints = new List<BuildingPoint>();

    private void Awake()
    {
        foreach (var point in _buildingPoints)
        {
            if (point.structure == null || point.structure.prefab == null)
            {
                Debug.LogWarning($"BuildingPoint at {point.location.name} has a missing structure or prefab.");
                continue;
            }
            Instantiate(point.structure.prefab, point.location.position, point.location.rotation);
            Debug.Log($"Spawned {point.structure.buildName} at {point.location.name}");
        }
    }
}