using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Vector3 _navDestination;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform playerPosition;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _navDestination = transform.position;
        InvokeRepeating("ThrowProjectile", 2, 2);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 direction = other.transform.position - transform.position;
            _navDestination = transform.position - direction;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _navDestination = transform.position;
    }
    private void Update()
    {
        _agent.SetDestination(_navDestination);
    }
    private void ThrowProjectile()
    {
        if(Physics.Linecast(transform.position, playerPosition.position))
        {
            Vector3 direction = playerPosition.position - transform.position;
            Instantiate(projectile, transform.position, Quaternion.LookRotation(direction));
        }
    }
}
