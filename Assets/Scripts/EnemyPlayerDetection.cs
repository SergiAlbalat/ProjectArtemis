using System.Text.RegularExpressions;
using UnityEngine;

public class EnemyPlayerDetection : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && !enemy.stuned && !enemy.captured)
        {
            enemy.run.SetCheck(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !enemy.captured)
        {
            enemy.run.SetCheck(false);
        }
    }
}
