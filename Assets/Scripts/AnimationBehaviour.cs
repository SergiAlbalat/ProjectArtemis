using UnityEngine;

public class AnimationBehaviour : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public void PlayerMove(float velocity, bool battleMode)
    {
        _animator.SetFloat("Velocity", velocity);
        _animator.SetBool("Battle", battleMode);
    }
}
