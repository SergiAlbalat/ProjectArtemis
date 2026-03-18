using UnityEngine;

public enum BuildType
{
    Empty,
    Harvester
}

[CreateAssetMenu(menuName = "Structures/Buildable")]
public class Stuctures : ScriptableObject
{
    public string buildName;
    public BuildType building;
    public GameObject prefab;
}