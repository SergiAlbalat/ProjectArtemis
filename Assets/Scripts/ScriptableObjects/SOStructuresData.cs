using System;
using UnityEngine;

public enum BuildType
{
    Empty,
    Harvester
}

[CreateAssetMenu(fileName= "SOStructures",menuName = "Structures/Buildable")]
public class StucturesData : ScriptableObject
{

    [Serializable]
    public class Structures
    {
        public BuildType building;
        public GameObject[] levels;
    }

    public Structures[] buildings;

    public GameObject GetBuilding(BuildType type, int level)
    {
        var entry = Array.Find(buildings, b => b.building == type);
        if (entry == null) { Debug.LogWarning($"BuildType {type} not found in registry"); return null; }
        if (level >= entry.levels.Length) { Debug.LogWarning($"{type} has no level {level}, clamping to max"); return entry.levels[^1]; }
        return entry.levels[level];
    }
}
