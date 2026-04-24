using UnityEngine;

public class AnimationBehaviour : MonoBehaviour
{
    public Animator animator;
    public void PlayerMove(float velocity, bool battleMode)
    {
        animator.SetFloat("Velocity", velocity);
        animator.SetBool("Battle", battleMode);
    }
    public void EnemyCaptured(bool option)
    {
        animator.SetBool("Captured", option);
    }
}
