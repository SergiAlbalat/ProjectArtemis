using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Vector3 _navDestination;
    public Stack<GameObject> _projectileStack  = new Stack<GameObject>();
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
            SpawnProjectile(direction);
        }
    }
    private void SpawnProjectile(Vector3 direction)
    {
        if(_projectileStack.Count > 0)
        {
            GameObject proj = _projectileStack.Pop();
            proj.transform.position = transform.position;
            proj.transform.rotation = Quaternion.LookRotation(direction);
            proj.SetActive(true);
        }
        else
        {
            GameObject proj = Instantiate(projectile, transform.position, Quaternion.LookRotation(direction));
            proj.GetComponent<Projectile>().enemy = this;
        }
    }
}
