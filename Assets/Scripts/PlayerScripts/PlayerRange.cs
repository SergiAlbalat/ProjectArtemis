using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    [SerializeField] private Player player;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("hello");
            player.inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("bye");
            player.inRange = false;
        }
    }
}
