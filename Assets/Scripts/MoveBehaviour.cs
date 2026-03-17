using UnityEngine;
[RequireComponent (typeof(CharacterController))]

public class MoveBehaviour : MonoBehaviour
{
    private CharacterController _cC;
    [SerializeField] private float velocity = 10;
    private void Awake()
    {
        _cC = GetComponent<CharacterController>();
    }
    public void PlayerMove(Vector3 direction)
    {
        Vector3 movement = direction.x * transform.right + direction.z * transform.forward;
        Move(movement);
    }
    public void Move(Vector3 movement)
    {
        _cC.Move(movement * velocity * Time.deltaTime);
    }
}
