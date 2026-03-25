using System.Collections;
using UnityEngine;
[RequireComponent(typeof(FloatBehaviour))]

public class Projectile : MonoBehaviour
{
    private FloatBehaviour _fB;
    public Enemy enemy;
    private void Awake()
    {
        _fB = GetComponent<FloatBehaviour>();
        Invoke("Despawn", 10);
    }
    private void FixedUpdate()
    {
        _fB.FloatForward();
    }
    private void Despawn()
    {
        if(enemy != null)
        {
            enemy._projectileStack.Push(gameObject);
            gameObject.SetActive(false);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        StartCoroutine(DespawnCooldown());
        if (hit.gameObject.CompareTag("Player"))
        {
            Player player = hit.gameObject.GetComponent<Player>();
            if (!player.stuned)
            {
                player.StartStun();
            }
        }
    }
    private IEnumerator DespawnCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        Despawn();
    }
}
