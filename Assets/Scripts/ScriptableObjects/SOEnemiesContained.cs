using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "SOEnemiesContained", menuName = "Scriptable Objects/EnemiesContained")]
public class EnemiesContained : ScriptableObject
{
    public List<StoredEnemyEntry> storedEnemies = new();

    [System.Serializable]
    public class StoredEnemyEntry
    {
        public Vector3 harvesterCoords;
        public GameObject enemyData;
        public int reward;
        public int model;
    }
    public bool CheckBuilding(Vector3 build) => storedEnemies.Exists(a => Vector3.Distance(a.harvesterCoords, build) < 0.01f);
    public void StoreEnemy(Vector3 building, GameObject enemy, int enemyModel)
    {
        var existing = storedEnemies.Find(e => e.harvesterCoords == building);
        int reward = GetReward();
        if (existing != null)
            existing.enemyData = enemy;
        else
            storedEnemies.Add(new StoredEnemyEntry { harvesterCoords = building, enemyData = enemy, reward = reward, model = enemyModel });
        Debug.Log(storedEnemies.Count);
    }
    private int GetReward()
    {
        switch (GameManager.gm.Difficulty)
        {
            case 1:
                return 6;
            case 2:
                return 9;
            case 3:
                return 12;
            default:
                return 0;
        }
    }

    public GameObject GetEnemyByBuild(Vector3 building)
    {
        var build = storedEnemies.Find(e => e.harvesterCoords == building);
        return build.enemyData;
    }
    
    public int GetEnemyModelByBuild(Vector3 building)
    {
        var build = storedEnemies.Find(e => e.harvesterCoords == building);
        return build.model;
    }

    public void DeleteEnemyOfBuild(Vector3 building)
    {
        var build = storedEnemies.Find(e => e.harvesterCoords == building);
        build.enemyData = null;
    }
}
