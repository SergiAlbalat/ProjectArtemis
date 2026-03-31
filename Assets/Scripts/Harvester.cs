using UnityEngine;

public class Harvester : MonoBehaviour
{
    [SerializeField] private Transform enemySpawn;
    public void InstanciateEnemies(GameObject enemy)
    {
        Instantiate(enemy, enemySpawn.position, Quaternion.identity);
    }
}
