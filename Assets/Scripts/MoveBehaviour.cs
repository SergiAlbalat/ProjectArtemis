using UnityEngine;
[RequireComponent (typeof(CharacterController))]

public class MoveBehaviour : MonoBehaviour
{
    private CharacterController _cC;
    private Vector3 movement;
    private Boots _boots;
    [SerializeField] private float velocity = 10;
    private void Start()
    {
        _cC = GetComponent<CharacterController>();
        _boots = GetComponent<Boots>();
    }
    public void PlayerMove(Vector3 direction)
    {
        movement = direction.x * transform.right + direction.z * transform.forward;
    }
    
    private void FixedUpdate()
    {
        _cC.Move(Time.deltaTime * velocity * movement);
    }
    public void AjustVelocity(float debuff)
    {
        velocity *= debuff;
        velocity += _boots.SpeedBuff;
    }
}
