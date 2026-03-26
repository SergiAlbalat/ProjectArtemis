using UnityEngine;

public class Harvester : MonoBehaviour
{
    public GameObject containedEnemy;
    [SerializeField] private Transform enemySpawn;
    public void StoreEnemy()
    {
        if (GameManager.gm.capturedEnemy != null && containedEnemy == null)
        {
            containedEnemy = GameManager.gm.capturedEnemy.prefab;
            GameManager.gm.capturedEnemy = null;
        }
        if (containedEnemy != null)
        {
            Instantiate(containedEnemy, enemySpawn);
        }
    }
}
