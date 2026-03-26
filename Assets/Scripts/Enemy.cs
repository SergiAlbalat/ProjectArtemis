using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour, IStun
{
    private NavMeshAgent _agent;
    private Vector3 _navDestination;
    public int CurrentHP;
    public Stack<GameObject> _projectileStack  = new Stack<GameObject>();
    public bool captured = false;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private SOEnemies enemyData;
    public bool stuned = false;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _navDestination = transform.position;
        InvokeRepeating("ThrowProjectile", 2, 2);
        CurrentHP = enemyData.MaxHP;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !stuned)
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
        if (!captured)
        {
            _agent.SetDestination(_navDestination);
            Debug.Log(CurrentHP);
            if (CurrentHP <= 0)
            {
                GameManager.gm.CaptureEnemy(enemyData);
            }
        }
    }
    private void ThrowProjectile()
    {
        if (captured)
            return;
        if(Physics.Linecast(transform.position, playerPosition.position) && !stuned)
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
    public void StartStun()
    {
        StartCoroutine(Stun());
    }
    public IEnumerator Stun()
    {
        stuned = true;
        _navDestination = transform.position;
        yield return new WaitForSeconds(5);
        stuned = false;
    }
}
