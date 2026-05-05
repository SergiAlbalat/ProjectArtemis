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
    private TimeSpan _harvestObjective;
    private float _timeLeft;
    private int _level;
    public void InstanciateEnemies(GameObject enemy, int model, float time)
    {
        containedEnemy = Instantiate(enemy, enemySpawn.position, Quaternion.identity);
        containedEnemy.GetComponent<Enemy>().captured = true;
        containedEnemy.GetComponent<Enemy>().UpdateModel(model);
        Debug.Log("Harvester Level: " + _level);
        _harvestObjective = (DateTime.Now.AddMinutes(time) - DateTime.Now) / _level;
        _timeLeft = (float)_harvestObjective.TotalSeconds;
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
            _timeLeft -= Time.deltaTime;
            if(_timeLeft > 0)
            {
                timer.text = _timeLeft.ToString("F2");
                _finished = false;
            }
            else
            {
                timer.text = "Ready";
                _finished = true;
            }
        }
    }
    public void SetLevel(int level)
    {
        _level = level + 1;
    }
}
