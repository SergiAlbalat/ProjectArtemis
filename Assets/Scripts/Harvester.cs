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
            GameObject enemy = Instantiate(containedEnemy, enemySpawn.position, Quaternion.identity);
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.captured = true;
        }
    }
}
