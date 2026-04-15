using System;
using TMPro;
using UnityEngine;

public class TimerBehaviour : MonoBehaviour
{
    [SerializeField] private SOEnemiesDiffiicultyStructure enemiyTypes;
    [SerializeField] private TextMeshProUGUI timerText;
    private float _timeLeft;
    private void Start()
    {
        _timeLeft = enemiyTypes.enemyTypes[GameManager.gm.Difficulty - 1].Timer;
        timerText.text = _timeLeft.ToString("F2");
    }
    private void Update()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            timerText.text = _timeLeft.ToString("F2");
        }
        else
        {
            GameManager.gm.LoadBase();
        }
    }
}
