using System;
using TMPro;
using UnityEngine;

public class TimerBehaviour : MonoBehaviour
{
    [SerializeField] private SOEnemiesDiffiicultyStructure enemiyTypes;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI stunTimerText;
    private bool _stoped = false;
    private bool _stunned = false;
    private float _timeLeft;
    private float _timeStunLeft;
    private void Start()
    {
        _timeLeft = enemiyTypes.enemyTypes[GameManager.gm.Difficulty - 1].Timer;
        timerText.text = _timeLeft.ToString("F2");
        stunTimerText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (_timeLeft > 0 && !_stoped)
        {
            _timeLeft -= Time.deltaTime;
            timerText.text = _timeLeft.ToString("F2");
            if (_stunned && _timeStunLeft > 0)
            {
                _timeStunLeft -= Time.deltaTime;
                stunTimerText.text = _timeStunLeft.ToString("F2");
            }
            else if(_stunned && _timeStunLeft <= 0)
            {
                stunTimerText.gameObject.SetActive(false);
            }
        }
        else if(!_stoped)
        {
            GameManager.gm.LoadBase();
        }
    }
    public void StopTimer()
    {
        _stoped = true;
    }
    public void StunTimer(float stunTime)
    {
        _stunned = true;
        _timeStunLeft = stunTime;
        stunTimerText.gameObject.SetActive(true);
        stunTimerText.text = _timeStunLeft.ToString("F2");
    }
}
