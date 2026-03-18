using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class FloatBehaviour : MonoBehaviour
{
    private CharacterController _cC;
    private void Awake()
    {
        _cC = GetComponent<CharacterController>();
    }
    public void FloatForward()
    {
        _cC.Move(transform.forward);
    }
}
