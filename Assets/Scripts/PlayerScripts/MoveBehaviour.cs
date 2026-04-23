using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent (typeof(CharacterController))]

public class MoveBehaviour : MonoBehaviour
{
    private CharacterController _cC;
    private AnimationBehaviour _aB;
    private Vector3 movement;
    private Boots _boots;
    private bool _inBattle;
    [SerializeField] private float velocity = 10;
    private void Awake()
    {
        _cC = GetComponent<CharacterController>();
        _boots = GetComponent<Boots>();
        _aB = GetComponent<AnimationBehaviour>();
        if(SceneManager.GetActiveScene().name == "Battle1")
        {
            _inBattle = true;
        }
        else
        {
            _inBattle = false;
        }
    }
    public void PlayerMove(Vector3 direction)
    {
        movement = direction.x * transform.right + direction.z * transform.forward;
    }
    
    private void FixedUpdate()
    {
        _cC.Move(Time.deltaTime * velocity * movement);
        _aB.PlayerMove(Vector3.Magnitude(movement), _inBattle);
    }
    public void AjustVelocity(float debuff)
    {
        velocity *= debuff;
        velocity += _boots.SpeedBuff;
    }
}
