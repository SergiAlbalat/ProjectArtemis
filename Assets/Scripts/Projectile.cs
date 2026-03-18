using UnityEngine;
[RequireComponent(typeof(FloatBehaviour))]

public class Projectile : MonoBehaviour
{
    private FloatBehaviour _fB;
    private void Awake()
    {
        _fB = GetComponent<FloatBehaviour>();
    }
    private void FixedUpdate()
    {
        _fB.FloatForward();
    }
}
