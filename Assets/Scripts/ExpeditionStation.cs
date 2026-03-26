using UnityEngine;

public class ExpeditionStation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.gm.LoadBattle();
        }
    }
}
