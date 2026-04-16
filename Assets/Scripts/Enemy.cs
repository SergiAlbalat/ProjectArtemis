using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(SphereCollider))]

public class Enemy : MonoBehaviour, IStun
{
    private NavMeshAgent _agent;
    private Player _player;
    private float _currentHP;
    private float _speedDebuff;
    private float _stunTime;
    private float _stunForce;
    public Stack<GameObject> _projectileStack  = new Stack<GameObject>();
    public bool captured = false;
    private float _patrolRange;
    [SerializeField] private SphereCollider patrolSphere;
    private SONode _currentNode;
    public Condition run;
    public Condition die;
    [SerializeField] private GameObject projectile;
    public SOEnemies enemyData;
    [SerializeField] private SONode rootNode;
    public bool stuned = false;
    private void Awake()
    {
        _currentNode = rootNode.Children.Last();
        run = new Condition("Run");
        die = new Condition("Die");
        ChangeNode();
    }
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        InvokeRepeating("ThrowProjectile", 2, 2);
        _currentHP = enemyData.MaxHP;
        _speedDebuff = enemyData.SpeedDebuff;
        _stunTime = _player.Stunner.GetStunForce() - enemyData.StunResistance;
        _stunForce = enemyData.StunForce;
        if(_stunTime < 0)
            _stunTime = 0;
        _patrolRange = patrolSphere.radius;
        if (SceneManager.GetActiveScene().name == "Base")
        {
            captured = true;
        }else if(SceneManager.GetActiveScene().name == "Battle")
        {
            PlayerVelocityDebuff();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !stuned && !captured)
        {
            run.SetCheck(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !captured)
        {
            run.SetCheck(false);
            _agent.SetDestination(transform.position);
        }
    }
    private void Update()
    {
        if (!captured)
        {
            _currentNode.OnUpdate(this);
            Debug.Log(_currentHP);
        }
    }
    private void ThrowProjectile()
    {
        if (captured || !run.GetCheck() || _player == null)
            return;
        if(Physics.Linecast(transform.position, _player.transform.position) && !stuned)
        {
            Vector3 direction = _player.transform.position - transform.position;
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
            proj.GetComponent<Projectile>().StunForce = _stunForce;
        }
    }
    public void StartStun()
    {
        StartCoroutine(Stun(_stunTime));
    }
    public IEnumerator Stun(float time)
    {
        stuned = true;
        _agent.SetDestination(transform.position);
        yield return new WaitForSeconds(time);
        stuned = false;
    }
    public void ChangeNode()
    {
        StartCoroutine(WaitToTheEndOfFrame());
    }
    private IEnumerator WaitToTheEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        foreach (SONode node in rootNode.Children)
        {
            if (node.StartCondition(this))
            {
                if (_currentNode != null)
                {
                    _currentNode.OnEnd(this);
                }
                _currentNode = node;
                _currentNode.OnStart(this);
                break;
            }
        }
    }
    public void SetPatrolDestination()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
        {
            Vector3 newDestination = GetRandomPoint(transform.position, _patrolRange);
            if (newDestination != Vector3.zero)
            {
                _agent.SetDestination(newDestination);
            }
        }
    }
    private Vector3 GetRandomPoint(Vector3 center, float range)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }
        return Vector3.zero;
    }
    public void RunUpdate()
    {
        if (!stuned)
        {
            Vector3 direction = _player.transform.position - transform.position;
            for(int i = 0; i < 100;i++)
            {
                NavMeshHit hit;
                if (NavMesh.SamplePosition(direction, out hit, 1, NavMesh.AllAreas))
                {
                    _agent.SetDestination(transform.position - direction);
                    return;
                }
                else
                {
                    direction *= 0.1f;
                }
            }
        }
    }
    public void OnHurt(float damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            Debug.Log("Enemy died");
            die.SetCheck(true);
        }
    }
    private void PlayerVelocityDebuff()
    {
       _player.AjustMovement(_speedDebuff);
    }
}
