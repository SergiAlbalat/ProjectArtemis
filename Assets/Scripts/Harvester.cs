using System;
using TMPro;
using UnityEngine;

public class Harvester : BuildManager
{
    [SerializeField] private Transform enemySpawn;
    [SerializeField] private TextMeshPro timer;
    private GameObject containedEnemy;
    private bool _active = false;
    private bool _finished = false;
    private DateTime _harvestObjective;
    public void InstanciateEnemies(GameObject enemy, int model, float time)
    {
        containedEnemy = Instantiate(enemy, enemySpawn.position, Quaternion.identity);
        containedEnemy.GetComponent<Enemy>().captured = true;
        containedEnemy.GetComponent<Enemy>().UpdateModel(model);
        _harvestObjective = DateTime.Now.AddMinutes(time);
        _active = true;
    }
    public override void Interact()
    {
        if(containedEnemy != null && _finished)
        {
            Destroy(containedEnemy);
            BaseManager.bm.HarvestEnemy(transform.position);
        }
    }
    private void Update()
    {
        if (_active)
        {
            Debug.Log(_harvestObjective);
            float timeLeft = (float)(_harvestObjective - DateTime.Now).TotalSeconds;
            if(timeLeft > 0)
            {
                timer.text = timeLeft.ToString("F2");
                _finished = false;
            }
            else
            {
                timer.text = "Ready";
                _finished = true;
            }
        }
    }
}
