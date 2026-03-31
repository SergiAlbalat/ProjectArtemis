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
    }
    public bool CheckBuilding(Vector3 build) => storedEnemies.Exists(a => Vector3.Distance(a.harvesterCoords, build) < 0.01f);
    public void StoreEnemy(Vector3 building, GameObject enemy)
    {
        var existing = storedEnemies.Find(e => e.harvesterCoords == building);
        if (existing != null)
            existing.enemyData = enemy;
        else
            storedEnemies.Add(new StoredEnemyEntry { harvesterCoords = building, enemyData = enemy });
    }

    public GameObject GetEnemyByBuild(Vector3 building)
    {
        var build = storedEnemies.Find(e => e.harvesterCoords == building);
        return build.enemyData;
    }

    public void DeleteEnemyOfBuild(Vector3 building)
    {
        var build = storedEnemies.Find(e => e.harvesterCoords == building);
        build.enemyData = null;
    }
}
