using UnityEngine;
[RequireComponent (typeof(CharacterController))]

public class MoveBehaviour : MonoBehaviour
{
    private CharacterController _cC;
    private Vector3 movement;
    [SerializeField] private float velocity = 10;
    private void Awake()
    {
        _cC = GetComponent<CharacterController>();
    }
    public void PlayerMove(Vector3 direction)
    {
        movement = direction.x * transform.right + direction.z * transform.forward;
    }
    
    private void FixedUpdate()
    {
        _cC.Move(Time.deltaTime * velocity * movement);
    }
}
