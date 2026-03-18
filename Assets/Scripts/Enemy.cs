using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Vector3 _navDestination;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _navDestination = transform.position;
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
}
