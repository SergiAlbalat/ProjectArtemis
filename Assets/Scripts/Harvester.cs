using UnityEngine;

public class Harvester : BuildManager
{
    [SerializeField] private Transform enemySpawn;
    private GameObject containedEnemy;
    public void InstanciateEnemies(GameObject enemy)
    {
        containedEnemy = Instantiate(enemy, enemySpawn.position, Quaternion.identity);
        containedEnemy.GetComponent<Enemy>().captured = true;
    }
    public override void Interact()
    {
        if(containedEnemy != null)
        {
            Destroy(containedEnemy);
            BaseManager.bm.HarvestEnemy(transform.position);
        }
    }
}
